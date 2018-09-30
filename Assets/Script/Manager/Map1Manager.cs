using UnityEngine;

// 스테이지 1 - 1의 투명벽과 목표를 설정한다
public class Map1Manager : Game_Manager
{
    protected override void Start()
    {
        Gates(4);

        for (var i = 0; i < gates.Length - 1; i++)
            gates[i].wall = GameObject.Find(string.Format("Invisible Wall ({0})", i + 1)).GetComponent<InvisibleWall>();

        gates[0].goal = 7;
        gates[1].goal = 21;
        gates[2].goal = 32;
        gates[3].goal = 42;
    }
}
