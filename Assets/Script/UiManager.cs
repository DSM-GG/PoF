using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// UI (체력, 결과 창) 을 관리
public class UiManager : MonoBehaviour
{
    private Player player;
    private GameObject result, fail;
    private Text subTitle;
    private Image hpBar;
    private Image background;

    // 플레이어, 결과창, 자막, HP바 을 캐싱
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        result = transform.Find("Result").gameObject;
        fail = result.transform.Find("Fail").gameObject;

        subTitle = transform.Find("SubTitle").GetComponent<Text>();
        hpBar = transform.Find("Profile").Find("HP").GetComponent<Image>();

        background = result.GetComponent<Image>();
    }

    // 플레이어의 HP를 받아서 체력바를 변환
    private void Update()
    {
        var nowHp = player.Hp;
        hpBar.fillAmount = nowHp / 6250;
    }

    // Clear, Fail 시 활성되는 UI 담당
    public IEnumerator ResultUiActive(bool isClear)
    {
        result.SetActive(true);

        if (isClear)
            yield return StartCoroutine(FadeOut());
        else
            fail.SetActive(true);
    }

    // 자막에 글 출력
    public void SubTitle(string value = "")
    {
        subTitle.text = value;
    }

    public IEnumerator FadeOut()
    {
        WaitForSecondsRealtime waitSec = new WaitForSecondsRealtime(0.02f);
        for (var alpha = 0; alpha <= 255; alpha+=2)
        {
            yield return waitSec;
            Color color = new Vector4(0, 0, 0, alpha / 255f);
            background.color = color;
        }
    }
}
