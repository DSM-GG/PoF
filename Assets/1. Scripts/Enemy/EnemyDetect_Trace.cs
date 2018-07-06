// EnemyDtect_Trace

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect_Trace : MonoBehaviour
{

    public bool isDetecting = false;
    public GameObject target = null;
    CircleCollider2D circle;
    EnemyStat stat;

    private void Start()
    {
        // EnemyStat에 있는 추격 감지 거리값을 얻어와서 콜라이더에 적용.
        circle = GetComponent<CircleCollider2D>();
        float size = gameObject.GetComponentInParent<EnemyStat>().detectRange;
        circle.radius = size;

        stat = GetComponentInParent<EnemyStat>();

    }

    // 추적 사거리 내에 들어왔는지 확인

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!stat.isZombie)
            if (collision.tag == "Player")
            {
                isDetecting = true;
                target = collision.gameObject;
            }
        else
            if(collision.tag == "Enemy")
            {
                isDetecting = true;
                target = collision.gameObject;
            }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!stat.isZombie)
            if (collision.tag == "Player")
            {
                Debug.Log("Object has Exit");
                isDetecting = false;
                target = null;
            }
        else 
            if (collision.tag == "Enemy")
            {
                Debug.Log("Object has Exit");
                isDetecting = false;
                target = null;
            }
    }
}