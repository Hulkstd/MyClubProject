using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStage : MonoBehaviour {

    GameObject[,] maze;
    GameObject[,] backgrounds;

    public Sprite[] wallSprite; /*벽1, 벽2, 플길1, 플길2, 타워1, 타워2*/

    // Use this for initialization
    void Start () {
        LoadMaze();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /*  txt 구조
    width :
    height :
    waypoints :

    (맵)

    (웨이포인트 1)

    (웨이포인트 2)

        .
        .
        .

    (웨이포인트 n)
     
    */
    void LoadMaze()  /* □ : 벽, ◇ : 플레이어 길, ↑ ↓ → ←, ↖ ↙ ↘ ↗, ┌ └ ┘ ┐, ① ~ ⑮ : 웨이포인트, △ : 타워 설치 가능,*/
    {
        TextAsset text = Resources.Load(SceneManager.GetActiveScene().name/*"Stage" + 1 스테이지 번호 할당*/) as TextAsset;

        GameObject wall = GameObject.Find("Wall").gameObject;
        GameObject playerField = GameObject.Find("PlayerField").gameObject;
        GameObject towerField = GameObject.Find("TowerField").gameObject;
        GameObject wayPoints = GameObject.Find("WayPoints").gameObject;

        string str = text.text;
        string[] lines = str.Split('\n');

        int width = int.Parse(lines[0].Split(':')[1]);
        int height = int.Parse(lines[1].Split(':')[1]);
        int wayPointCount = int.Parse(lines[2].Split(':')[1]);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                switch (lines[y + 4].ToCharArray()[x])
                {
                    case '□':
                        Spawn(wallSprite[0], new Vector2((width / 2) - width + x, (height / 2) - height + y), wall);
                        break;
                    case '◇':
                        Spawn(wallSprite[1], new Vector2((width / 2) - width + x, (height / 2) - height + y), playerField);
                        break;
                    case '↑':
                        Spawn(wallSprite[2], new Vector2((width / 2) - width + x, (height / 2) - height + y), playerField);
                        break;
                    case '↓':
                        Spawn(wallSprite[3], new Vector2((width / 2) - width + x, (height / 2) - height + y), playerField);
                        break;
                    case '←':
                        Spawn(wallSprite[4], new Vector2((width / 2) - width + x, (height / 2) - height + y), playerField);
                        break;
                    case '→':
                        Spawn(wallSprite[5], new Vector2((width / 2) - width + x, (height / 2) - height + y), playerField);
                        break;
                    case '↖':
                        Spawn(wallSprite[6], new Vector2((width / 2) - width + x, (height / 2) - height + y), playerField);
                        break;
                    case '↙':
                        Spawn(wallSprite[7], new Vector2((width / 2) - width + x, (height / 2) - height + y), playerField);
                        break;
                    case '↘':
                        Spawn(wallSprite[8], new Vector2((width / 2) - width + x, (height / 2) - height + y), playerField);
                        break;
                    case '↗':
                        Spawn(wallSprite[9], new Vector2((width / 2) - width + x, (height / 2) - height + y), playerField);
                        break;
                    case '┌':
                        Spawn(wallSprite[10], new Vector2((width / 2) - width + x, (height / 2) - height + y), playerField);
                        break;
                    case '└':
                        Spawn(wallSprite[11], new Vector2((width / 2) - width + x, (height / 2) - height + y), playerField);
                        break;
                    case '┘':
                        Spawn(wallSprite[12], new Vector2((width / 2) - width + x, (height / 2) - height + y), playerField);
                        break;
                    case '┐':
                        Spawn(wallSprite[13], new Vector2((width / 2) - width + x, (height / 2) - height + y), playerField);
                        break;
                    case '△':
                        Spawn(wallSprite[14], new Vector2((width / 2) - width + x, (height / 2) - height + y), towerField);
                        break;
                }
            }
        }


        for (int i = 1; i <= wayPointCount; i++)
        {
            GameObject g = new GameObject();
            g.name = "WayPoint" + i;
            g.transform.SetParent(wayPoints.transform);

            //Debug.Log(i * (height + 1) + 4 + " ~ " + (i * (height + 1) + 4 + height).ToString());
             
            GameObject[] points = new GameObject[50];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    switch (lines[i * (height + 1) + 4 + y].ToCharArray()[x])
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
                            GameObject h = Spawn(null, new Vector2((width / 2) - width + x, (height / 2) - height + y));
                            h.name = "WayPoint" + lines[i * (height + 1) + 4].ToCharArray()[x];
                            points[(int)(lines[i * (height + 1) + 4 + y].ToCharArray()[x] - '0')] = h;
                            break;

                        default:
                            if (lines[i * (height + 1) + 4 + y].ToCharArray()[x] >= 'a' && lines[i * (height + 1) + 4 + y].ToCharArray()[x] <= 'z')
                            {
                                GameObject p = Spawn(null, new Vector2((width / 2) - width + x, (height / 2) - height + y));
                                p.name = "WayPoint" + (lines[i * (height + 1) + 4 + y].ToCharArray()[x]).ToString();
                                points[(int)(lines[i * (height + 1) + 4 + y].ToCharArray()[x] - 'a') + 10] = p;
                            }
                            break;
                    }

                }
            }
            foreach (GameObject t in points)
            {
                if(t != null)
                    t.transform.SetParent(g.transform);
            }
        }

        wayPoints.GetComponent<WayPoint>().Load();
    }

    GameObject Spawn(Sprite sprite, Vector2 vec, GameObject parents = null)
    {
        GameObject g = new GameObject();
        g.AddComponent<SpriteRenderer>().sprite = sprite;
        g.transform.position = vec;
        if(parents == null)
        {
            g.name = "WayPoint";
            return g;
        }
        g.transform.SetParent(parents.transform);

        return g;
    }
}
