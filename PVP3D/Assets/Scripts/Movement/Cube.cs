using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Movement {

	// Use this for initialization
	void Start () {
        IsOnGround = true;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        Jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        CollisionOnGround(collision);
    }
}
