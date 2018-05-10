using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    EnemyStat stat;
    EnemyDetect_Attack detectAttack;

    private void Start()
    {
        detectAttack = GetComponent<EnemyDetect_Attack>();
        stat = GetComponentInParent<EnemyStat>();

        StartCoroutine("Attack");
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

        StartCoroutine("Attack");
    }


}