using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public TowerAI callme = null;
	// Use this for initialization
	void Start () {
        StartCoroutine(Destroy());
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, 1).normalized * 45f * Time.deltaTime , Space.Self);
	}

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(transform.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Shield")
        {
            int a = Random.Range(0, 6);

            int T = new UpgradeList(new FileLoader().Load()).IncreaseEffect;

            if (a <= T)
            {
                Destroy(gameObject);
            }
        }
    }
}
