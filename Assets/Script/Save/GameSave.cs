using System.Collections;
using UnityEngine;

public abstract class GameSave : MonoBehaviour {

    protected int nowKill;
    protected GameObject player;
    protected Game_Manager manager;
    private GameObject setWindow;
    private bool isOn = false;
    
	private void Awake () {
        player = GameObject.FindWithTag("Player");
        setWindow = GameObject.FindWithTag("Setting");
        nowKill = PlayerPrefs.GetInt("Kill Monster");
	}

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        setWindow.SetActive(false);
        KillEnemy();
    }

    protected abstract void KillEnemy();

	public void Save () {
        nowKill = PlayerPrefs.GetInt("Kill Monster");
        PlayerPrefs.SetInt("Kill Monster", ++nowKill);
	}

    public void Setting()
    {
        isOn = !isOn;
        setWindow.SetActive(isOn);
    }

    public void Init()
    {
        PlayerPrefs.SetInt("Kill Monster", 0);
    }
}
