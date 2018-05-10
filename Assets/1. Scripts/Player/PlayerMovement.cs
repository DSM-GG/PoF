using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float jumpPower;
    public float speed;  // 캐릭터 이동속도

    short direction = 1; // 캐릭터 이동 방향
    bool isJumping = false;

    Rigidbody2D rigid;
    Animator animator;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Movement();
        Jump();
    }

    // 이동 함수 
    void Movement()
    {
        CheckDirection();

        // 만약 지금 이동키를 누르고 있다면
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);
        }

        return;
    }

    // 캐릭터의 이동 방향을 확인하는 함수 
    void CheckDirection()
    {
        // 오른쪽 이동 
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Right");
            direction = 1;
            
        }
        // 왼쪽 이동 
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Left");
            direction = -1;
        }

        // 오브젝트의 방향 전환
        transform.localScale = new Vector3(direction * 1, 1, 1);

        return;
    }

    void CheckGrounded()
    {
        if (rigid.velocity == Vector2.zero)
            isJumping = false;

        return;
    }

    void Jump()
    {
        CheckGrounded();

        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            Debug.Log("Jump");
            Vector2 dir = new Vector2(0, jumpPower);
            rigid.AddForce(dir, ForceMode2D.Impulse);
        }

        return;
    }
}
