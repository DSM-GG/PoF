using System.Collections;
using UnityEngine;

// 적의 이동, 공격, HP 관리
public class Enemy : Charater
{
    private Game_Manager manager;
    private Player player;

    // GameManager, 플레이어, 자신의 HP바 를 캐싱
    private void Awake()
    {
        manager = GameObject.FindWithTag("Manager").GetComponent<Game_Manager>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // 각 캐릭터의 스테이터스 할당
    private void Start()
    {
        hp = 6250;
        attackPower = 0;
        attackSpeed = 0;
        moveSpeed = 0;
        jumpPower = 12.5f;
    }

    private void Update()
    {
        if (!(hp > 0))
        {
            manager.Kill();
            Destroy(gameObject);
        }

        // 적 코드 추가
    }

    private void OnCollisionEnter2D(Collision2D attacker)
    {
        if (attacker.gameObject.CompareTag("Player"))
            if (player.CanControl)
                attacker.gameObject.GetComponent<Player>().Hit(attackPower);
            else
                hp = 0;
    }
}
