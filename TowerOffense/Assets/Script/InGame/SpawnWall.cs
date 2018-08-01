using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnWall : MonoBehaviour {

    string[] lines;
    int wallCount;
    private int killCount;
    int count;

    public int KillCount
    {
        get
        {
            return killCount;
        }
        set
        {
            killCount = value;
        }
    }

	// Use this for initialization
	void Start () {
        TextAsset text = Resources.Load(SceneManager.GetActiveScene().name + "_Wall") as TextAsset;

        string str = text.text;
        lines = str.Split('\n');
        wallCount = int.Parse(lines[0].Split(':')[1]);
    }
	
	// Update is called once per frame
	void Update () {
		if(KillCount >= count + 2)
        {
            int LV, rotate;
            float x, y;
            
            x = (float)double.Parse(lines[2 + count / 2].Split()[0]);
            y = (float)double.Parse(lines[2 + count / 2].Split()[1]);
            LV = int.Parse(lines[2 + count / 2].Split()[2]);
            rotate = int.Parse(lines[2 + count / 2].Split()[3]);
            count += 2;
            Spawn(new Vector3(x, y, -1), LV, rotate);
        }
	}

    GameObject Spawn(Vector3 vec, int LV, float rotate)
    {
        GameObject g = Instantiate(Resources.Load("Prefab/EnemyPrefabs/WallLV" + LV)) as GameObject;
        g.transform.position = vec;
        g.transform.rotation = new Quaternion(0, 0, rotate, g.transform.rotation.w);

        return g;
    }
}
