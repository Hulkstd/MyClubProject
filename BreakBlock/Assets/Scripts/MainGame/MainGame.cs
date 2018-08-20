using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject InsArrow;

    public Vector3 origin;
    public Vector3 nowPosition;

    Dictionary<GameObject, Vector2> velocity = new Dictionary<GameObject, Vector2>();
    Dictionary<GameObject, Rigidbody2D> rig = new Dictionary<GameObject, Rigidbody2D>();
    List<GameObject> Balls = new List<GameObject>();

    GameObject BallsObject;
    bool Flag = true;

    // Use this for initialization
    void Start()
    {
        BallsObject = GameObject.Find("Balls");
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D tmp;
        rig.TryGetValue(Balls[0], out tmp);
        //Debug.Log(Floor.count + " " + rig.Count);
        if (Floor.count == rig.Count)
        {
            if(!Flag)
            {
                Flag = true;
                GameObject g = Instantiate(Resources.Load("Ball"), BallsObject.transform, false) as GameObject;
                g.transform.position = tmp.transform.position;
            }

            if (Input.GetMouseButtonDown(0))
            { 
                origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                InsArrow = Instantiate(Arrow, origin - new Vector3(0, 0, -9), transform.rotation);
            }

            if (Input.GetMouseButton(0))
            {
                nowPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Quaternion rotate = Quaternion.LookRotation(InsArrow.transform.position - nowPosition, InsArrow.transform.TransformDirection(Vector3.back));
                
                InsArrow.transform.rotation = new Quaternion(0, 0, rotate.z, rotate.w);
            }

            if (Input.GetMouseButtonUp(0))
            {
                //Debug.Log((InsArrow.transform.rotation.eulerAngles.z >= 90) + " " + (InsArrow.transform.rotation.eulerAngles.z <= 270)+ " " + InsArrow.transform.rotation.eulerAngles.z);

                if (InsArrow.transform.rotation.eulerAngles.z >= 90 && InsArrow.transform.rotation.eulerAngles.z <= 270)
                {
                    Destroy(InsArrow);
                    return;
                }

                if (origin - nowPosition == Vector3.zero)
                {
                    Destroy(InsArrow);
                    return;
                }
                Vector3 move = origin - nowPosition;

                StartCoroutine("ShootBall", move);

                Destroy(InsArrow);

                /*
                rig.velocity = move.normalized * 10f;
                velocity = rig.velocity;
                */
            }
        }
        else
        {
            Flag = false;
        }
    }

    public void AddBall(GameObject obj)
    {
        Floor.count++;
        Balls.Add(obj);
        rig.Add(obj, obj.GetComponent<Rigidbody2D>());
        velocity.Add(obj, Vector3.zero);
    }

    public Rigidbody2D GetRigidbody2D(GameObject obj)
    {
        if (rig.ContainsKey(obj))
        {
            Rigidbody2D rigid;
            rig.TryGetValue(obj, out rigid);

            return rigid;
        }

        return null;
    }

    public Vector2 GetVelocity(GameObject obj)
    {
        if(velocity.ContainsKey(obj))
        {
            Vector2 vec;
            velocity.TryGetValue(obj, out vec);

            return vec;
        }

        return Vector2.zero;
    }

    IEnumerator ShootBall(Vector3 move)
    {
        yield return new WaitForSeconds(0.2f);

        move.Normalize();
        Floor.position = Vector3.zero;
        Floor.count = 0;
        foreach(var ball in Balls)
        {
            Rigidbody2D rigid;
            Vector2 velo;

            rig.TryGetValue(ball, out rigid);
            velocity.TryGetValue(ball, out velo);

            rigid.velocity = move * 10f;
            velo = rigid.velocity;

            velocity.Remove(ball);
            velocity.Add(ball, velo);

            yield return new WaitForSeconds(0.05f);
        }

        yield return null;
    }

    public void SetVelocity(GameObject obj,Vector2 vec)
    {
        velocity.Remove(obj);
        velocity.Add(obj, vec);
    }

}
