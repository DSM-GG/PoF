using UnityEngine;

// 모든 캐릭터 (플레이어, 적)의 기초 클래스
public class Charater : MonoBehaviour
{
    protected float hp;
    protected float attackPower;
    protected float attackSpeed;
    protected float moveSpeed;
    protected float jumpPower;

    public float Hp
    {
        get { return hp; }
    }

    public void Hit(float damage)
    {
        hp -= damage;
    }

    protected void Move(Vector2 movement)
    {
        Turn(movement.x);
        movement *= moveSpeed * Time.deltaTime;
        transform.Translate(movement, 0);
    }

    private void Turn(float x)
    {
        if (x == 1)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        if (x == -1)
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
