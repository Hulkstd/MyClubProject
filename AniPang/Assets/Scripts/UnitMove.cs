using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour {

    Vector3 origin;

    GameObject clickUnit;
    bool firstCheck;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            clickUnit = Camera.main.GetComponent<MainGame>().Find(origin);
            firstCheck = false;
            //Debug.Log(g);
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            GameObject g = Camera.main.GetComponent<MainGame>().Find(vec);

            if(g == clickUnit)
            {
                clickUnit.transform.GetChild(0).localPosition = Vector3.zero;
                return;
            }
            if(Vector3.Distance(clickUnit.transform.position, g.transform.position) > 1.0f)
            {
                return;
            }
            clickUnit.transform.GetChild(0).position = g.transform.position + new Vector3(0, 0, -0.1f) ; 
        }

        if(Input.GetMouseButtonUp(0))
        {
            origin = Vector3.zero;
            clickUnit.transform.GetChild(0).localPosition = Vector3.zero;
            clickUnit = null;
        }
	}
}
