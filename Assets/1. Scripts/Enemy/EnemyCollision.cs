using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

    public bool isTile = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Tile")
            isTile = true;
        else
            isTile = false;
    }

}
