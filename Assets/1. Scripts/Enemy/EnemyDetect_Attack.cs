using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect_Attack : MonoBehaviour
{
    // 좀비화 되었을 때 자폭하는 것을 구현할 것. 

    public bool isAttack = false;
    public GameObject attackTarget;

    EnemyStat stat;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        CircleCollider2D circle = GetComponent<CircleCollider2D>();
        float size = GetComponentInParent<EnemyStat>().attackRange;
        stat = GetComponentInParent<EnemyStat>();
        animator = GetComponentInParent<Animator>();

        circle.radius = size;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!stat.isZombie)
        {
            if (collision.tag == "Player")
            {
                Debug.Log("Called in Attack");
                isAttack = true;
                attackTarget = collision.gameObject;

                GetComponent<EnemyAttack>().StartCoroutine("Attack");
            }
            else
                Debug.Log("Called in Attack (Not Player)");
        }
        else
        {
            if(collision.tag == "Enemy")
            {
                // 좀비인 상태로 적이 사거리 내부에
                // 들어온다면 자폭을 한다. 
                GetComponent<EnemyAttack>().SuicideExplosion();
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!stat.isZombie)
        {
            if (collision.tag == "Player")
            {
                Debug.Log("Called in Attack");
                isAttack = false;
                attackTarget = null;
            }

            GetComponent<EnemyAttack>().StopCoroutine("Attack");
        }
        else
        {
            if(collision.tag == "Enemy")
            {
                isAttack = false;
                attackTarget = null;
            }
        }
        //isDetecting = false;
    }
}