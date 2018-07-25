using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public UpgradeList upgrade;
    Text UC;

    public void Speed()
    {
        if (upgrade.UpgradeCount > 0 && upgrade.Speed < 5)
        {
            upgrade.Speed = 1;
            upgrade.UpgradeCount--;
        }
    }

    public void HP()
    {
        if (upgrade.UpgradeCount > 0 && upgrade.HP < 5)
        {
            upgrade.HP = 1;
            upgrade.UpgradeCount--;
        }
    }

    public void Damage()
    {
        if (upgrade.UpgradeCount > 0 && upgrade.Damage < 5)
        {
            upgrade.Damage = 1;
            upgrade.UpgradeCount--;
        }
    }

    public void Duration()
    {
        if (upgrade.UpgradeCount > 0 && upgrade.Duration < 5)
        {
            upgrade.Duration = 1;
            upgrade.UpgradeCount--;
        }
    }

    public void IncreaseEffect()
    {
        if (upgrade.UpgradeCount > 0 && upgrade.IncreaseEffect  < 5)
        {
            upgrade.IncreaseEffect = 1;
            upgrade.UpgradeCount--;
        }
    }

    public void GetSpeed()
    {
        if (upgrade.UpgradeCount > 0 && upgrade.GetSpeed < 5)
        {
            upgrade.GetSpeed = 1;
            upgrade.UpgradeCount--;
        }
    }

    public void Max()
    {
        if (upgrade.UpgradeCount > 0 && upgrade.Max < 5)
        {
            upgrade.Max = 1;
            upgrade.UpgradeCount--;
        }
    }

    public void Back()
    {
        SaveData saveData = new SaveData(upgrade);
        saveData.Save();
        SceneManager.LoadScene(0);

    }

	// Use this for initialization
	void Start () {
        /*SaveData saveData = new FileLoader().Load();

        upgrade.Speed = saveData.Speed;
        upgrade.HP = saveData.HP;
        upgrade.Damage = saveData.Damage;

        upgrade.Duration = saveData.Duration;
        upgrade.IncreaseEffect = saveData.IncreaseEffect;

        upgrade.GetSpeed = saveData.GetSpeed;
        upgrade.Max = saveData.MaxMoney;*/

        upgrade = new UpgradeList(new FileLoader().Load());
        //new SaveData().Save();
        UC = GameObject.Find("UpgradeCount").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        UC.text = "Upgrade Count " + upgrade.UpgradeCount + " left";
	}
}
