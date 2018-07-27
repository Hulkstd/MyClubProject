using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour {

    private GameObject[,] unit;
    public string[] character;

	// Use this for initialization
	void Start () {
        unit = new GameObject[12, 20];

        character = new string[10];
        character[0] = "Fox";
        character[1] = "Dog";
        character[2] = "Racoon";
        character[3] = "Otter";
        character[4] = "Badger";
        character[5] = "Monkey";
        character[6] = "Seal";
        character[7] = "Wolf";
        character[8] = "Tiger";
        character[9] = "Sloth";

        for (int i=0; i<12; i++)
        {
            for(int j=0; j<20; j++)
            {
                GameObject spawn = Resources.Load("Prefabs/" + character[Random.Range(0, 9)]) as GameObject;

                unit[i,j] = Spawn(spawn, new Vector3((float)(-5.5 + i), (float)(-9.5 + j), -1.0f));
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject Spawn(GameObject g, Vector3 position)
    {
        GameObject unit = Instantiate(g) as GameObject;

        unit.transform.position = position;
        unit.transform.SetParent(GameObject.Find("Units").transform);

        return unit;
    }
}
