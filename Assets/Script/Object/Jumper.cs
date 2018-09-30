using UnityEngine;

// 점프대
public class Jumper : MonoBehaviour
{
    [SerializeField]
    private float jumpSpeed;

    // 플레이어가 점프대와 충돌 시 점프
    private void OnCollisionEnter2D(Collision2D check)
    {
        if (check.gameObject.CompareTag("Player") || check.gameObject.CompareTag("Enemy"))
            check.rigidbody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
    }
}
