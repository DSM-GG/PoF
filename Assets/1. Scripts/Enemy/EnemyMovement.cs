using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    // Private
    bool isTracing = false; // 적의 추적 플래그 

    SpriteRenderer spriteRenderer;
    EnemyDetect_Trace detect; // 플레이어 감지를 위한 스크립트 변수 
    GameObject target;  // 추적 대상(Player)
    EnemyStat stat;
    Animator animator;

    // public
    public int direction = 1; // 적의 방향  

    // Use this for initialization
    void Start () {
        detect = GetComponentInChildren<EnemyDetect_Trace>();
        stat = GetComponent<EnemyStat>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        StartCoroutine("ChangeFlag");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        CheckCollider();
        Movement();
	}

    // 몬스터의 이동을 담당 
    void Movement()
    {
        DecideDirection();

        transform.position += new Vector3(direction * stat.speed * Time.deltaTime, 0, 0);
        return;
    }

    // 몬스터의 이동 플래그를 확인, 갱신을 담당 
    void CheckCollider()
    {
        isTracing = detect.isDetecting;
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
        //if()
        // 추적 중이라면 
        if (isTracing && target.tag == "Player")
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

        // 스프라이트 이미지 방향을 바꿈. 
        if (direction == 1)
            spriteRenderer.flipX = false;
        else
            spriteRenderer.flipX = true;

        // 추적을 안하고있다면 

        return;
    }

    IEnumerator ChangeFlag()
    {
        if (!isTracing)
        {
            direction = Random.Range(-1, 2);
            Debug.Log(direction);
        }
        yield return new WaitForSeconds(stat.patrolTime);

        StartCoroutine("ChangeFlag");
    }

}
