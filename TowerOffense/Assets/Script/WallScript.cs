using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

    public float HP = 30f;
    List<GameObject> Bump_into = new List<GameObject>();
    public int Count = 0;
    bool CanAttack = true;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Delay", 0, 1f);
	}

    void Delay()
    {
        CanAttack = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (CanAttack && Bump_into.Count != 0)
        {
            HP -= Damaged();

            CanAttack = false;
        }        

        if(HP <= 0)
        {
            OnDestroys();
            Destroy(gameObject);
        }
	}
    public float Damaged()
    {
        float damage = 0f;

        foreach (GameObject g in Bump_into)
        {
            if (g != null)
            {
                damage += g.GetComponent<PlayerScript>().Damage;
            }
        }

        return damage;
    }
    public bool AddUnit(GameObject gameObject)
    {
        if (!Bump_into.Contains(gameObject))
        {
            Bump_into.Add(gameObject);
        }

        return true;
    }

    private void OnDestroys()
    {
        foreach(GameObject g in Bump_into)
        {
            if(g != null)g.GetComponent<PlayerScript>().movement.MoveSpeed = g.GetComponent<PlayerScript>().MoveSpeed;
        }
    }

    public void DestroyUnit(GameObject g)
    {
        Bump_into.Remove(g);
    }
}
