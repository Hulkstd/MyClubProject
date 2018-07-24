using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //StartCoroutine(Destroy());
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, 1).normalized * 30f * Time.deltaTime , Space.Self);
	}

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(transform.gameObject);
    }
}
