using UnityEngine;

public class ElevatorBump : MonoBehaviour {

    Elevator elevator;
    Vector3 myPos;

    private void Awake()
    {
        elevator = transform.parent.Find("Elevator").GetComponent<Elevator>();
        myPos = transform.position;
    }

    private void Update()
    {
        transform.position = myPos;
    }

    private void OnTriggerExit2D(Collider2D check)
    {
        if (check.CompareTag("Elevator"))
            elevator.Stop();  
    }
}
