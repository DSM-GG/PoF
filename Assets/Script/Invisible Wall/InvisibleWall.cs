using System.Collections;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    protected Game_Manager manager;
    private UiManager canvas;
    private GameSave save;
    new protected Collider2D collider;

    // Game Manager, Collider2D 를 캐싱
    protected void Awake()
    {
        manager = GameObject.FindWithTag("Manager").GetComponent<Game_Manager>();
        canvas = GameObject.FindWithTag("Canvas").GetComponent<UiManager>();
        save = GameObject.FindWithTag("Manager").GetComponent<GameSave>();
        collider = GetComponent<Collider2D>();
    }

    // 목표 킬 수를 달성하지 못하고 벽에 닿을 시 실행
    protected void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var leftEnemy = (manager.Goal - manager.KillCount).ToString();
            var message = "목표 킬 수까지 " + leftEnemy + " 남았습니다";
            StartCoroutine(Subtitle(message));
            StartCoroutine(Subtitle("", 3f));
        }
    }

    protected IEnumerator OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 투명 벽의 트리거가 아닌 캐릭터의 트리거로 발생하는 것을 방지
            if (collision.isTrigger) { yield break; };

            save.Save();
            StartCoroutine(Subtitle("세이브 되었습니다"));
            yield return new WaitForSeconds(3);
            canvas.SubTitle();
            Destroy(gameObject);
        }
    }

    // 목표 킬 수를 달성했을 시 실행
    public virtual void OpenGate()
    {
        try { collider.isTrigger = true; }
        catch (MissingReferenceException) {}  
    }

    // delay 초만 대기한 후 message를 띄운다
    private IEnumerator Subtitle(string message, float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        canvas.SubTitle(message);
    }
}