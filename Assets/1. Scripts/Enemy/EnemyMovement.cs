using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Private
    bool isTracing = false; // 적의 추적 플래그 
    bool isThereHole = false;
    int wallDirection = 0;

    EnemyGroundChecker checkGrounded;
    SpriteRenderer spriteRenderer;
    EnemyDetect_Trace detect; // 플레이어 감지를 위한 스크립트 변수 
    EnemyStat stat;
    Animator animator;

    // public
    public int direction = 0; // 적의 방향  
    public GameObject target;  // 추적 대상(Player)

    // Use this for initialization
    void Start()
    {
        target = null;
        detect = GetComponentInChildren<EnemyDetect_Trace>();
        stat = GetComponent<EnemyStat>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        checkGrounded = GetComponentInChildren<EnemyGroundChecker>();

        StartCoroutine("ChangeFlag");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckCollider();
        Movement();
    }

    // 몬스터의 이동을 담당 
    void Movement()
    {
        DecideDirection();

        Debug.Log("Moving");

        // 땅에 닿아 있을때만 이동 
        if (direction == checkGrounded.wallDirection * -1 || checkGrounded.wallDirection == 0)
            transform.position += new Vector3(direction * stat.speed * Time.deltaTime, 0, 0);
    }

    // 몬스터의 이동 플래그를 확인, 갱신을 담당 
    void CheckCollider()
    {
            isTracing = (detect.isDetecting || IsGameObjNull(target));
            Debug.Log("IsTracing : " + isTracing);

            if (detect.target)
                target = detect.target;

            if (direction == -1 || direction == 1)
            {
                animator.SetBool("IsWalking", true);
                animator.SetBool("IsIdle", false);
            }
            else
            {
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsIdle", true);
            }
        return;
    }

    // 몬스터의 이동 방향을 담당 
    void DecideDirection()
    {
        // 스프라이트 이미지 방향을 바꿈. 
        if (direction == 1)
            spriteRenderer.flipX = false;
        else
            spriteRenderer.flipX = true;


        if (target == null)
            return;

        // 좀비 X
        if (!stat.isZombie)
        {
            // 추적 중이라면
            if (target.tag == "Player" && isTracing)
            {
                if (target.transform.position.x >= transform.position.x)
                {
                    direction = 1;
                }
                else
                {
                    direction = -1;
                }

                if (Mathf.Abs(transform.position.x - target.transform.position.x) > stat.ExitRange ||
                 Mathf.Abs(transform.position.y - target.transform.position.y) > 2)
                {
                    target = null;
                }


            }
        }
        // 좀비 O
        else
        {
            if (target.tag == "Enemy")
            {
                if (target.transform.position.x >= transform.position.x)
                {
                    direction = 1;
                }
                else
                {
                    direction = -1;
                }
            }
        }

        // 추적을 안하고있다면 
    }

    IEnumerator ChangeFlag()
    {
        if (stat.isZombie)
            yield return null;

        if (!isTracing)
        {
            direction = Random.Range(-1, 2);
            Debug.Log("Chagedirection() : " + direction);
        }
        yield return new WaitForSeconds(stat.patrolTime);

        StartCoroutine("ChangeFlag");
    }

    public void SetTarget(GameObject obj)
    {
        target = obj;
    }

    public GameObject GetTarget()
    {
        return target;
    }

    bool IsGameObjNull(GameObject gameObject)
    {
        if (gameObject == null)
            return false;
        else
            return true;
    }

    public void AlertObservers(string msg)
    {
        // 애니메이션이 끝났다면 해당 오브젝트를 삭제
        if (msg.Equals("AnimationEnd"))
        {
            EnemyAttack temp = GetComponentInChildren<EnemyAttack>();
            temp.animationEnd = true;
        }
    }
}