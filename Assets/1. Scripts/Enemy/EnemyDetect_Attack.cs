using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect_Attack : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        CircleCollider2D circle = GetComponent<CircleCollider2D>();
        float size = GetComponentInParent<EnemyStat>().attackRange;

        circle.radius = size;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Called in Attack");
            //isDetecting = true;
            //target = collision.gameObject;
        }
        else
            Debug.Log("Called in Attack (Not Player)");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Debug.Log("Called in Attack");
        //isDetecting = false;
    }
}
