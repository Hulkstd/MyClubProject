using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    public static Vector3 position;
    public static int count;

	// Use this for initialization
	void Start () {
        position = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (position == Vector3.zero)
        {
            position = collision.transform.position;
        }
        else
        {
            while(true)
            {
                collision.transform.position = Vector3.Lerp(collision.transform.position, position, 0.2f);

                if(collision.transform.position == position)
                {
                    break;
                }
            }
        }
        count++;
    }
}
