using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnTower : MonoBehaviour {

    string[] lines;
    int height;
    int width;
    int towerCount;
    private int spawnUnitCount = 0;
    int count;

    public int SpawnUnitcount
    {
        get
        {
            return spawnUnitCount;
        }

        set
        {
            spawnUnitCount = value;
        }
    }

    // Use this for initialization
    void Start () {
        LoadTower();	
	}
	
	// Update is called once per frame
	void Update () {
		if(SpawnUnitcount >= count + 2)
        {
            count += 2;

            int x, y, LV;

            x = int.Parse(lines[(height + 1) + 3 + count / 2].Split()[0]);
            y = int.Parse(lines[(height + 1) + 3 + count / 2].Split()[1]);
            LV = int.Parse(lines[(height + 1) + 3 + count / 2].Split()[2]);

            Spawn(new Vector3(x, y, -1), LV);
        }
	}

    void LoadTower()
    {
        TextAsset text = Resources.Load(SceneManager.GetActiveScene().name + "_Enemy") as TextAsset;

        string str = text.text;
        lines = str.Split('\n');
        width = int.Parse(lines[0].Split(':')[1]);
        height = int.Parse(lines[1].Split(':')[1]);
        towerCount = int.Parse(lines[2].Split(':')[1]);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                switch (lines[y+4].ToCharArray()[x])
                {
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        GameObject h = Spawn(new Vector3((width / 2) - width + x, (height / 2) - height + y, -1 ), int.Parse(lines[y+4].ToCharArray()[x].ToString()));
                        break;
                }

            }
        }
    }

    GameObject Spawn(Vector3 vec, int LV)
    {
        GameObject g = Instantiate(Resources.Load("Prefab/EnemyPrefabs/EnemyLV" + LV)) as GameObject;
        g.transform.position = vec;
        g.transform.SetParent(GameObject.Find("Towers").transform);
        return g;
    }
}
