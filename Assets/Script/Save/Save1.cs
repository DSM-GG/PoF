using UnityEngine;
using UnityEngine.SceneManagement;

public class Save1 : GameSave {

    private Transform[] spawnPoint = new Transform[3];
    private GameObject[] invisibleWall = new GameObject[3];
    private GameObject[] enemys = new GameObject[3];

    protected override void KillEnemy()
    {
        if (nowKill > 3)
            SceneManager.LoadScene("Stage 2");

        manager = GameObject.FindWithTag("Manager").GetComponent<Game_Manager>();

        for (int i = 0; i < 3; i++)
        {
            spawnPoint[i] = GameObject.Find(string.Format("Spawn ({0})", i + 1)).transform;
            invisibleWall[i] = GameObject.Find(string.Format("Invisible Wall ({0})", i + 1));
            enemys[i] = GameObject.Find(string.Format("Enemy Stage {0}", i + 1));
        }

        int enemy = 0;

        for (int i = nowKill; i > 0; i--)
        {
            enemy += enemys[i - 1].transform.childCount;

            Destroy(enemys[i - 1]);
            Destroy(invisibleWall[i - 1]);
        }

        manager.KillCount = enemy;
        
        if (nowKill > 0)
            player.transform.position = spawnPoint[nowKill - 1].position;
    }
}
