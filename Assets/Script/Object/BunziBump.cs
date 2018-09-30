using UnityEngine;

// 도약 후 땅에 착지 했을 시 번지 대와 자신을 제거한다
public class BunziBump : MonoBehaviour
{
    [SerializeField]
    private GameObject wall;
    private GameObject bunzi;

    // 번지대 를 캐싱한다
    private void Awake()
    {
        bunzi = transform.parent.gameObject;
    }

    // 플레이어와 충돌 시 번지 대와 자신을 제거한다
    private void OnTriggerEnter2D(Collider2D check)
    {
        if (check.CompareTag("Player"))
        {
            wall.SetActive(true);
            Destroy(bunzi);
        }
    }
}
