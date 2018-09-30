using System.Collections;
using UnityEngine;

// 플레이어가 충돌 시 자막을 띄우고, 번지를 한다
public class BunziControl : MonoBehaviour
{
    private Player player;
    private UiManager canvas;

    private Vector2 bunziPower = new Vector2(11.2f, 15);

    // 플레이어, 플레이어의 Rigidbody2D 를 캐싱한다
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        canvas = GameObject.FindWithTag("Canvas").GetComponent<UiManager>();
    }

    // 플레이어가 도약 지점에 도달 시 발동
    private void OnTriggerEnter2D(Collider2D check)
    {
        if (check.CompareTag("Player") && !check.isTrigger)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -3);
            canvas.SubTitle("W를 눌러 도약하세요");
            player.CanControl = false;
            StartCoroutine(Bunzi());
        }
    }

    // 플레이어를 다시 정상화하고 자신을 삭제한다
    private void OnDestroy()
    {
        player.CanControl = true;
        canvas.SubTitle();
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    // W를 누르면 점프를 실행한다
    private IEnumerator Bunzi()
    {
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.W)) && player.OnGround);
        
        canvas.SubTitle();
        player.GetComponent<Rigidbody2D>().AddForce(bunziPower, ForceMode2D.Impulse);
        yield return StartCoroutine(SpeedControl());
    }

    // 도약 시에 슬로우 모션
    private IEnumerator SpeedControl()
    {
        WaitForSeconds waitSec = new WaitForSeconds(0.01f);
        var x = 0f;

        while (true)
        {
            Time.timeScale = (7f * Mathf.Pow(x, 2)) + (-3.2f * x) + 0.5f;
            yield return waitSec;
            x += 0.01f;
        }
    }
}
