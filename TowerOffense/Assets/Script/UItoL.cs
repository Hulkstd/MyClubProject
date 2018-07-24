using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UItoL : MonoBehaviour {

    public GameObject g;

	// Use this for initialization
	void Start () {
        transform.position = Camera.main.ScreenToWorldPoint(g.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
