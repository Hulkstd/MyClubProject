using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnit : MonoBehaviour {

    private MainGame mainGame;
    GameObject spawnPoint;

	// Use this for initialization
	void Start () {
        mainGame = Camera.main.GetComponent<MainGame>();
        spawnPoint = GameObject.Find("SpawnPoint");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Spawn(int LV)
    {
        GameObject unit = mainGame.AddUnit(LV);

        if (unit != null)
        {
            unit.transform.position = spawnPoint.transform.position;

            unit.transform.SetParent(GameObject.Find("Players").transform);
        }
    }

    public void SpawnTower(int LV, Vector3 position)
    {
        GameObject tower = Instantiate(Resources.Load("Prefab/EnemyPrefabs/TowerLV" + LV)) as GameObject;
        mainGame.AddTower(tower);

        if (tower != null)
        {
            tower.transform.position = position;

            tower.transform.SetParent(GameObject.Find("Towers").transform);
        }
    }
}
