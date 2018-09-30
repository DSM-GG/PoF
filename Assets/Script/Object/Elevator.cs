using System.Collections;
using UnityEngine;

// 엘리베이터가 작동하고 멈추는 것까지를 구현
public class Elevator : MonoBehaviour {

    private IEnumerator control = null;

    [SerializeField]
    private float speed;

    private void OnTriggerEnter2D(Collider2D passenger)
    {
        if (passenger.gameObject.CompareTag("Player") && control == null)
        {
            control = Activate();
            StartCoroutine(control);
        }
    }

    public void Stop()
    {
        StopCoroutine(control);
    }

    private IEnumerator Activate()
    {
        yield return new WaitForSeconds(2);
        WaitForSeconds waitFor = new WaitForSeconds(0.03f);

        while(true)
        {
            transform.Translate(Vector3.up * speed * 0.03f);
            yield return waitFor;
        }
    }
}
