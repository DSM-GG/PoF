using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManageZombie : MonoBehaviour {

    EnemyStat stat;

	// Use this for initialization
	void Start () {
        stat = GetComponent<EnemyStat>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckHp();

	}

    void CheckHp()
    {
        // 적의 체력이 limitHp 이하라면 좀비화가 된다. 
        if(!stat.isZombie)

        if(stat.hp <= stat.limitHp)
        {
            stat.isZombie = true;
            transform.tag = "Zombie";
        }
    }
}
