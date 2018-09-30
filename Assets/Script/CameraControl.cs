using UnityEngine;

// 카메라가 플레이어를 따라오는 것을 구현
public class CameraControl : MonoBehaviour {

    private float followSpeed = 3;
    private Transform player;
    public Vector3 offset;

    public float FollowSpeed
    {
        set { followSpeed = value; }
    }

    // 플레이어의 transform 을 캐싱
	void Awake () {
        player = GameObject.FindWithTag("Player").transform;
	}

	void FixedUpdate () {
        var TargetPos = new Vector2(
            player.position.x + offset.x,
            player.position.y + offset.y);
            
        transform.position = new Vector3 (
            Mathf.Lerp(transform.position.x, TargetPos.x, Time.deltaTime * followSpeed), 
            Mathf.Lerp(transform.position.y, TargetPos.y, Time.deltaTime * followSpeed),
            player.position.z + offset.z);
    }
}
