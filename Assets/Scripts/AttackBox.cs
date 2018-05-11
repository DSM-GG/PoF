using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    [SerializeField] private GameObject Player = null;
    [SerializeField] private float AttackForce = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Vector2 force = (other.gameObject.transform.position - Player.transform.position).normalized * AttackForce;
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(force);
            Debug.Log("아파욧!" + force);
        }
    }
}
