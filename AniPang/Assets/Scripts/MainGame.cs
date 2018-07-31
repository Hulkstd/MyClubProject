using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour {

    private GameObject[,] unit;
    private GameObject[,] copy;
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

        InvokeRepeating("CheckField", 0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {

	}

    void CheckField()
    {
        copy = unit;
            
        Debug.Log("2");
        for (int j = 0; j < 20; j++)
        {
            for (int i = 0; i < 12; i++)
            {
                if (unit[i, j] == null)
                {
                    Debug.Log("스폰중");

                    GameObject spawn = Resources.Load("Prefabs/" + character[Random.Range(0, 9)]) as GameObject;

                    unit[i, j] = Spawn(spawn, new Vector3((float)(-5.5 + i), (float)(-9.5 + j), -1.0f));
                }
            }
        }

        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                bool flag = Check(i, j);
                if(flag)
                {
                    DownUnit();
                }
            }
        }
    }

    void DownUnit()
    {
        for (int j = 1; j < 20; j++)
        {
            for (int i = 0; i < 12; i++)
            {
                if (unit[i, j - 1] == null)
                {
                    Debug.Log("!");
                    unit[i, j - 1] = unit[i, j];
                    unit[i, j] = null;
                }
            }
        }

        for (int j = 0; j < 20; j++)
        {
            for (int i = 0; i < 12; i++)
            {
                if (unit[i, j] == null)
                {
                    Debug.Log("스폰중");

                    GameObject spawn = Resources.Load("Prefabs/" + character[Random.Range(0, 9)]) as GameObject;

                    unit[i, j] = Spawn(spawn, new Vector3((float)(-5.5 + i), (float)(-9.5 + j), -1.0f));
                }
            }
        }
    }

    public bool CheckPang(GameObject a, GameObject b)
    {
        copy = unit;

        Vector2Int q, w;

        q = new Vector2Int();
        w = new Vector2Int();

        for (int i = 0; i < 12; i++) 
        {
            for (int j = 0; j < 20; j++)
            {
                if(copy[i,j] == a)
                {
                    q.x = i;
                    q.y = j;
                }
                if(copy[i, j] == b)
                {
                    w.x = i;
                    w.y = j;
                }
            }
        }

        GameObject tmp = copy[q.x, q.y];
        copy[q.x, q.y] = copy[w.x, w.y];
        copy[w.x, w.y] = tmp;

        bool Check1 = Check(w.x, w.y);
        bool Check2 = Check(q.x, q.y);

        if(!Check1 && !Check2)
        {
            Debug.Log("1");
            return false;
        }

        DownUnit();
        
        return true;
    }

    private bool Check(int x, int y)
    {
        bool flag = false;
        List<Vector2Int> CheckList = new List<Vector2Int>();

        CheckList.Add(new Vector2Int(x, y));
        if (!(x - 2 < 0 || x > 11 || y < 0 || y > 19 ))
        {
            if (copy[x, y].name == copy[x - 1, y].name && copy[x, y].name == copy[x - 2, y].name)
            {
                CheckList.Add(new Vector2Int(x - 1, y));
                CheckList.Add(new Vector2Int(x - 2, y));
                flag = true;
            }
        }

        if (!(x - 1 < 0 || x + 1 > 11 || y < 0 || y > 19 ))
        {
            if (copy[x, y].name == copy[x - 1, y].name && copy[x, y].name == copy[x + 1, y].name)
            {
                CheckList.Add(new Vector2Int(x - 1, y));
                CheckList.Add(new Vector2Int(x + 1, y));
                flag = true;
            }
        }


        if (!(x < 0 || x + 2 > 11 || y < 0 || y > 19 ))
        {
            if (copy[x, y].name == copy[x + 2, y].name && copy[x, y].name == copy[x + 1, y].name)
            {
                CheckList.Add(new Vector2Int(x + 2, y));
                CheckList.Add(new Vector2Int(x + 1, y));
                flag = true;
            }
        }

        if (!(x < 0 || x > 11 || y < 0 || y + 2 > 19 ))
        {
            if (copy[x, y].name == copy[x, y + 1].name && copy[x, y].name == copy[x, y + 2].name)
            {
                CheckList.Add(new Vector2Int(x, y + 2));
                CheckList.Add(new Vector2Int(x, y + 1));
                flag = true;
            }
        }

        if (!(x < 0 || x > 11 || y - 1 < 0 || y + 1 > 19 ))
        {
            if (copy[x, y].name == copy[x, y + 1].name && copy[x, y].name == copy[x, y - 1].name)
            {
                CheckList.Add(new Vector2Int(x, y - 1));
                CheckList.Add(new Vector2Int(x, y + 1));
                flag = true;
            }
        }

        if (!(x < 0 || x > 11 || y - 2 < 0 || y > 19 ))
        {
            if (copy[x, y].name == copy[x, y - 2].name && copy[x, y].name == copy[x, y - 1].name)
            {
                CheckList.Add(new Vector2Int(x, y - 2));
                CheckList.Add(new Vector2Int(x, y - 1));
                flag = true;
            }
        }

        if(!flag)
        {
            return false;
        }

        foreach(var item in CheckList)
        {
            if (unit[item.x, item.y] != null)
            {
                Destroy(unit[item.x, item.y]);
                unit[item.x, item.y] = null;
            }
        }

        return true;
    }

    public GameObject Spawn(GameObject g, Vector3 position)
    {
        GameObject unit = Instantiate(g) as GameObject;

        unit.transform.position = position;
        unit.transform.SetParent(GameObject.Find("Units").transform);
        unit.tag = "Unit";
        unit.transform.GetChild(0).tag = "Unit";
        return unit;
    }

    public GameObject Find(Vector3 vec)
    {
        RaycastHit raycastHit;

        //Debug.Log(vec);
        
        //Debug.DrawRay(vec, Vector3.forward * 10, Color.red, 0.5f);
        
        if (Physics.Raycast(vec, Vector3.forward ,out raycastHit, 100))
        {
            //Debug.Log("1");
            if(raycastHit.transform.tag == "Unit")
            {
                //Debug.Log("1"); 
                return raycastHit.transform.gameObject;
            }
        }

        return null;
    }
}
