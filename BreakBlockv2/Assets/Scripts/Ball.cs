using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

    public Rigidbody2D rig;

	// Use this for initialization
	void Start () {
        rig.velocity = new Vector2(0, -4.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);

        if(collision.gameObject.name == "Edge")
        {
            if(collision.tag == "Floor")
            {
                // 재시작
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                return;
            }
            ChangeDirection(collision.gameObject.tag);
        }
        else if(collision.gameObject.name == "Block")
        {
            ChangeDirection(collision.gameObject.tag);

            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.name == "Stick")
        {
            float a = collision.transform.position.x - transform.position.x;
            //Debug.Log(a * -5);
            rig.velocity = new Vector2(a * -5, -rig.velocity.y);

            Vector2 vec = rig.velocity.normalized;
            vec *= 5;
            rig.velocity = new Vector2(vec.x, vec.y);

            /*if(a <= 0)
            {
                rig.velocity = new Vector2(-Mathf.Round(rig.velocity.x), -rig.velocity.y);
            }
            else
            {
                rig.velocity = new Vector2(Mathf.Round(rig.velocity.x), -rig.velocity.y);
            }*/
        }
    }

    void ChangeDirection(string tag)
    {
        if(tag == "Up")
        {
            rig.velocity = new Vector2(rig.velocity.x, -rig.velocity.y);
        }
        else if(tag == "Side")
        {
            Debug.Log("1");
            rig.velocity = new Vector2(-rig.velocity.x, rig.velocity.y);
        }
    }
}
