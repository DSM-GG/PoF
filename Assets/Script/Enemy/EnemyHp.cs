using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    private Enemy charater;
    private Image hpBar;

    // 자신, 자신의 캐릭터 캐싱
    private void Awake()
    {
        charater = transform.parent.parent.GetComponent<Enemy>();
        hpBar = gameObject.GetComponent<Image>();
    }

    private void Start()
    {
        gameObject.transform.lossyScale.Set(1, 1, 1);
        gameObject.transform.localScale.Set(1, 1, 1);
    }

    public void Update()
    {
        hpBar.fillAmount = charater.Hp / 6250;
    }
}