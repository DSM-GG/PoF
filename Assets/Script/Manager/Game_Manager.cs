using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// 투명 벽 자체와 벽의 목표 수를 정의
public struct Gate
{
    public InvisibleWall wall;
    public int goal;
}

// 현재 킬 수를 통해 투명 벽 전체를 관리하고 Clear와 Fail을 관리한다
public abstract class Game_Manager : MonoBehaviour
{
    protected Gate[] gates;
    private int nowStage, killCount = 0;
    private UiManager ui;

    public int KillCount
    {
        get { return killCount; }
        set { killCount = value; }
    }

    public int Goal
    {
        get { return gates[nowStage].goal; }
    }

    // 캔버스 를 캐싱
    private void Awake()
    {
        ui = GameObject.FindWithTag("Canvas").GetComponent<UiManager>();
    }

    // 현재 씬에 있는 투명 벽의 정보를 gates에 할당, 대입
    protected abstract void Start();

    // 킬 수가 목표 수를 넘으면 투명 벽을 트리거화
    private void Update()
    {
        if (killCount >= gates[nowStage].goal)
        {
            gates[nowStage].wall.OpenGate();
            nowStage++;
        } 
    }
    
    // 각 맵마다 투명 벽의 수가 다르기에 스크립트에서 부른 것의 +1만큼 동적할당 한다
    // Index Out을 방지하기 위해 벽의 수 +1 만큼 할당한다
    protected void Gates(int value)
    {
        gates = new Gate[value + 1];
        gates[gates.Length - 1].wall = null;
        gates[gates.Length - 1].goal = int.MaxValue;
    }

    public void Kill()
    {
        killCount++;
    }

    // Clear, Fail 시 실행
    public IEnumerator Result(bool isClear, float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        yield return StartCoroutine(ui.ResultUiActive(isClear));
        
        var scene = SceneManager.GetActiveScene();
        var nowScene = scene.buildIndex;

        Time.timeScale = 0;

        if (isClear)
            SceneManager.LoadScene(nowScene + 1);
        else
            if (Input.anyKey)
                SceneManager.LoadScene(nowScene);

        Time.timeScale = 1;
    }
}