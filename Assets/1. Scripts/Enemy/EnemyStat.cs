using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour {

    public float hp;          // 체력
    public float speed;       // 이동속도
    public float damage;      // 공격력 
    public float attackTerm;  // 공격 텀 (현재 공격과 다음 공격시의 시간 차)
    public float detectRange; // 감지 사거리
    public float attackRange; // 공격 사거리 
    public float patrolTime;  // 적의 순찰 시간
    public float limitHp;     // 좀비화가 되기 위한 일정 체력 

    public bool isCallFriendly;
    public bool isZombie = false;
    
    // 동료 의식으로 호출되었을 때,
    // 플레이어를 인지할 수 있는 최대 거리
    public Vector2 callRange;
    
    // 좀비화 되었을시, 자폭할 때 그 폭발 범위
    public Vector2 suicideBoomRange;
    public float suicideBoomDamgage; // 자폭시 폭발 데미지 

    public float ExitRange; 

}
