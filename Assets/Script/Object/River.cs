using System.Collections;
using UnityEngine;

// 강에 빠졌을 때 데미지를 입는 것을 구현
public class River : MonoBehaviour
{
    private bool alreadyRun;
    private WaitForSeconds waitSec;

    private void Start()
    {
        waitSec = new WaitForSeconds(0.5f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Enemy"))
            StartCoroutine(InRiver(collision));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Enemy"))
        {
            StopCoroutine(InRiver(collision));
        }    
    }

    private IEnumerator InRiver(Collider2D collision)
    {
        // 코루틴이 중복 발생하는 것을 막음
        if (alreadyRun) { yield break; }

        alreadyRun = true;
        yield return waitSec;
        collision.GetComponent<Charater>().Hit(312.5f);
        alreadyRun = false;
    }
}
