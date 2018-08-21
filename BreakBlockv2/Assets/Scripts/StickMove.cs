using UnityEngine;
using System.Collections;

public class StickMove : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-0.1f, 0));
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(0.1f, 0));
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5.6f, 5.6f), transform.position.y);
    }
}
