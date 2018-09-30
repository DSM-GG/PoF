using UnityEngine;

// 돌진대, 충돌 시 게임 클리어
public class Rusher : MonoBehaviour
{
    private Game_Manager manager;
    private Player player;
    private GameObject lastWall;

    private const float moveSpeed = 150f;

    // 플레이어, 마지막 벽 을 캐싱
    private void Awake()
    {
        manager = GameObject.FindWithTag("Manager").GetComponent<Game_Manager>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        lastWall = GameObject.Find("Last Wall");
    }

    // 플레이어가 돌진대와 충돌 시 돌진, 3초 후 게임 클리어
    private void OnCollisionEnter2D(Collision2D check)
    {
        if (check.gameObject.CompareTag("Player"))
        {
            player.CanControl = false;
            lastWall.SetActive(false);
            check.rigidbody.AddForce(Vector2.right * moveSpeed, ForceMode2D.Impulse);
            StartCoroutine(manager.Result(true));
        }
    }
}