
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundChecker : MonoBehaviour
{

    public bool isThereWall = false;
    public int wallDirection = 0;

    // 여기 문제있음 수정 바람 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            if (transform.parent.position.x > collision.gameObject.transform.position.x)
                wallDirection = -1;
            else
                wallDirection = 1;

            isThereWall = true;
            Debug.Log("Detected Wall");
            Debug.Log("Wall Direction : " + wallDirection);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            isThereWall = false;
            wallDirection = 0;
        }
    }
}
