using System.Collections;
using UnityEngine;

// 플레이어의 이동, 공격, HP 관리
public class Player : Charater
{
    // 상용화 시에는 true를 false로 바꿀것
    private const bool GM = true;

    private Game_Manager manager;

    private new Collider2D collider;
    private new Rigidbody2D rigidbody;

    private Vector2 inputKey;
    private bool onGround, upgrade, canUpgrade, canControl = true;
    private const float rushSpeed = 25f, downSpeed = 11f;

    public bool CanControl
    {
        get { return canControl; }
        set { canControl = value; }
    }

    public bool OnGround
    {
        get { return onGround; }
    }

    // GameManager, Rigidbody2D, Collider2D 를 캐싱
    private void Awake()
    {
        manager = GameObject.FindWithTag("Manager").GetComponent<Game_Manager>();
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // 스테이터스, 변수 초기화
    private void Start()
    {
        hp = 6250;
        attackPower = 1250;
        attackSpeed = 0;
        moveSpeed = 13;
        jumpPower = 7.5f;

        canUpgrade = true;
        canControl = true;
    }

    private void Update()
    {
        if (!(hp > 0))
            StartCoroutine(manager.Result(false));

        if (!canControl) { return; }

        var GMmode = rigidbody.isKinematic;

        inputKey.x = Input.GetAxisRaw("Horizontal");
        inputKey.y = Input.GetAxisRaw("Vertical");

        if (!GMmode)
        {
            User(inputKey);
            inputKey.y = 0;
        }

        Move(inputKey);
    }

    // 모드 변환, 업그레이드 쿨타임 타이머의 시작
    private void LateUpdate()
    {
        if (!canUpgrade)
            StartCoroutine(UpgradeTimer());

        if (Input.GetKeyUp(KeyCode.Alpha1))
            ChangeMode(true);

        else if (Input.GetKeyUp(KeyCode.Alpha2))
            ChangeMode(false);
    }

    // GM 모드와 Player 모드를 변환
    private void ChangeMode(bool nowGM)
    {
        //if (!GM) { return; }

        collider.isTrigger = nowGM;
        rigidbody.velocity = new Vector3(0, 0, 0);
        rigidbody.isKinematic = nowGM;
    }

    private void User(Vector2 inputKey)
    {
        // 좌 쉬프트를 눌렀고, 강화 쿨타임이 지났을 시 강화 스킬 활성
        if (Input.GetKey(KeyCode.LeftShift) && canUpgrade)
            upgrade = true;
        else
            upgrade = false;

        if (upgrade) { Rush(inputKey.x); }
        
        if (inputKey.y == 1) { Jump(); }
        else if (inputKey.y == -1 && inputKey.x == 0) { Down(); }
        else {
            var rotate = new Vector3(0, transform.rotation.y, 0);
            transform.rotation = Quaternion.Euler(rotate.normalized.x, rotate.normalized.y * 180, rotate.normalized.z); }
    }

    private void Rush(float x)
    {
        if (x == 0) { return; }

        // 돌진 거리가 일정하도록 현재 플레이어의 물리량을 없앰
        rigidbody.velocity = new Vector3(0, 0, 0);
        rigidbody.AddForce(Vector2.right * x * rushSpeed, ForceMode2D.Impulse);
        
        StartCoroutine(RushLimit());
        canUpgrade = false;
        upgrade = false;
    }

    private void Jump()
    {

        if (!onGround) { return; }

        var jump = jumpPower;

        if (upgrade)
        {
            jump *= 1.4f;
            canUpgrade = false;
            upgrade = false;
        }

        rigidbody.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        onGround = false;
    }

    private void Down()
    {
        if (!onGround) { return; }

        transform.rotation = Quaternion.Euler(0, transform.rotation.y * 180, 90);
    }

    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.CompareTag("Enemy"))
            enemy.gameObject.GetComponent<Enemy>().Hit(attackPower);
    }

    // 플레이어가 땅에 있는지 확인
    private void OnTriggerStay2D(Collider2D collision)
    {
        bool onLand = collision.CompareTag("Ground");
        bool onEnemy = collision.CompareTag("Enemy");
        bool onElevator = collision.CompareTag("Elevator");

        if (onLand || onEnemy || onElevator)
            onGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bool onLand = collision.CompareTag("Ground");
        bool onEnemy = collision.CompareTag("Enemy");
        bool onElevator = collision.CompareTag("Elevator");

        if (onLand || onEnemy || onElevator)
            onGround = false;
    }

    private IEnumerator UpgradeTimer()
    {
        yield return new WaitForSeconds(2);
        canUpgrade = true;
    }

    private IEnumerator RushLimit()
    {
        yield return new WaitForSeconds(0.1f);
        rigidbody.velocity = new Vector3(0, 0, 0);
    }
}