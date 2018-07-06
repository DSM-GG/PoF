using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    EnemyStat stat;
    EnemyDetect_Attack detectAttack;
    Animator animator;
    public bool animationEnd = false;

    private void Start()
    {
        detectAttack = GetComponent<EnemyDetect_Attack>();
        stat = GetComponentInParent<EnemyStat>();
        animator = GetComponentInParent<Animator>();

        
    }
    
    IEnumerator Attack()
    {
        if (detectAttack.isAttack)
        {
            //detectAttack.attackTarget.GetComponent</* 여기에 플레이어 체력 변수가 담겨있는 스크립트 */>.hp -= stat.damage;
            // 공격 애니메이션 호출 
            Debug.Log("Attacked!");
        }
       
        yield return new WaitForSeconds(stat.attackTerm);

        // 공격 텀 시간이 다 지난 후 플레이어가 존재한다면
        // 데미지를 가한다. 
        if(detectAttack.attackTarget)
        {
            // 공격을 가하는 메서드 호출 
            //detectAttack.attackTarget.GetComponent<Player>.HitDamage(stat.damage);
        }

        StartCoroutine("Attack");
    }

    public void SuicideExplosion()
    {
        Vector2 enemyPosition2D = new Vector2(transform.position.x, transform.position.y);
        Collider2D[] nearObject = Physics2D.OverlapBoxAll(enemyPosition2D, stat.suicideBoomRange, 0);

        foreach (Collider2D col2D in nearObject)
        {
            if (col2D.tag == "Enemy" && col2D.transform != transform)
            {
                Debug.Log("Explosion");
                animator.SetTrigger("Explosion");
                col2D.GetComponent<EnemyStat>().hp -= stat.suicideBoomDamgage;
                StartCoroutine("CheckAnimationEnd");
            }
         }
    }

    IEnumerator CheckAnimationEnd()
    {
        if (animationEnd)
        {
            Debug.Log("Die");
            Destroy(transform.parent.gameObject);
        }
        else
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine("CheckAnimationEnd");
        }
    }

    // 애니메이션 종료 체크하는 코루틴 생성할 것.

}