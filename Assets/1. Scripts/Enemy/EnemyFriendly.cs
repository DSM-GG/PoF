using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFriendly : MonoBehaviour {

    EnemyStat stat;
    GameObject target;

	// Use this for initialization
	void Start () {
        stat = GetComponent<EnemyStat>();
    }
	
	// Update is called once per frame
	void Update () {
        CallFriends();
	}

    void CallFriends()
    {
        // 좀비 상태일때는 수행하지 않음.
        if (stat.isZombie)
            return;

        Vector2 enemyPosition2D = new Vector2(transform.position.x, transform.position.y);
        Collider2D[] nearObject = Physics2D.OverlapBoxAll(enemyPosition2D, stat.callRange, 0);

        foreach (Collider2D col2D in nearObject)
        {
            if (col2D.tag == "Enemy" && col2D.transform != transform)
            {
                target = GetComponent<EnemyMovement>().GetTarget();
                col2D.GetComponent<EnemyMovement>().SetTarget(target);
            }
        }

    }

}
