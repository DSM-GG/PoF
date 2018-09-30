using UnityEngine;

// 투명 벽과 같은 기능을 하는 보이는 벽 관리
public class VisibleWall : InvisibleWall
{
    [SerializeField]
    private GameObject[] blocks;

    // 콜라이더를 캐싱
    private new void Awake()
    {
        collider = GetComponent<Collider2D>();
        base.Awake();
    }

    public override void OpenGate()
    {
        base.OpenGate();
        for (var i = 0; i < blocks.Length; i++)
            blocks[i].SetActive(false);
    }
}
