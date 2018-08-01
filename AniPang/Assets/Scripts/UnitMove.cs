using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour {

    Vector3 origin;

    GameObject clickUnit;
    GameObject nowUnit;
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
            if(Vector3.Distance(clickUnit.transform.position, g.transform.position) > 1.2f)
            {
                return;
            }
            nowUnit = g;
            clickUnit.transform.GetChild(0).position = g.transform.position + new Vector3(0, 0, -0.1f) ; 
        }

        if(Input.GetMouseButtonUp(0))
        {
            Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(nowUnit == clickUnit)
            {
                origin = Vector3.zero;
                clickUnit = null;
                nowUnit = null;
                return;
            }
            /*Vector3 tmp = nowUnit.transform.position;
            nowUnit.transform.position = clickUnit.transform.position;
            clickUnit.transform.position = tmp;

            nowUnit.transform.GetChild(0).localPosition = Vector3.zero;
            clickUnit.transform.GetChild(0).localPosition = Vector3.zero;*/

            if(Camera.main.GetComponent<MainGame>().CheckPang(nowUnit, clickUnit))
            {
                Vector3 tmp = nowUnit.transform.position;
                nowUnit.transform.position = clickUnit.transform.position;
                clickUnit.transform.position = tmp;

                nowUnit.transform.GetChild(0).localPosition = Vector3.zero;
                clickUnit.transform.GetChild(0).localPosition = Vector3.zero;
            }
            else
            {
                clickUnit.transform.GetChild(0).localPosition = Vector3.zero;
            }

            origin = Vector3.zero;
            nowUnit = null;
            clickUnit = null;
        }
	}
}
