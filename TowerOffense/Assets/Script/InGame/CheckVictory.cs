using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckVictory : MonoBehaviour {

    PlayTime playTime;
    public Text vicOrDef;
    public int goalUnitCount = 0;
    public int goalUnit;

	// Use this for initialization
	void Start () {
        playTime = GetComponent<PlayTime>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playTime.playTime <= 0f)
        {
            Defeat();
        }
        else if (goalUnitCount >= goalUnit)
        {
            Victory();
        }
	}

    void Defeat()
    {
        vicOrDef.text = "Defeat";
        vicOrDef.gameObject.SetActive(true);
        Time.timeScale = 0;
       
        Camera.main.GetComponent<MainGame>().IsGameEnd = true;
    }

    void Victory()
    {
        vicOrDef.text = "Victory";
        vicOrDef.gameObject.SetActive(true);
        Time.timeScale = 0;
        SaveData sv = new FileLoader().Load();
        sv.UpgradeCount += 3;
        sv.Save();
        Camera.main.GetComponent<MainGame>().IsGameEnd = true;
    }
}
