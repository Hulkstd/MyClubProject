using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

    public float RotateSensitivity = 2.0f;

    public Camera Cam;

    // Use this for initialization
    void Start () {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * RotateSensitivity, Space.World);
        Cam.transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * Time.deltaTime * RotateSensitivity, Space.Self);
        
        if(Cam.transform.rotation.eulerAngles.x < 20.0f)
        {
            Cam.transform.rotation = Quaternion.Euler(new Vector3(20.0f, 
                                                      Cam.transform.rotation.eulerAngles.y, 
                                                      Cam.transform.rotation.eulerAngles.z));
        }
        if(Cam.transform.rotation.eulerAngles.x > 30.0f)
        {
            Cam.transform.rotation = Quaternion.Euler(new Vector3(30.0f, 
                                                      Cam.transform.rotation.eulerAngles.y, 
                                                      Cam.transform.rotation.eulerAngles.z));
        }
    }
}
