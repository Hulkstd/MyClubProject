 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float HP = 30f;
    public float Damage = 2f;
    public GameObject HPvar;
    public float MoveSpeed = 0;
    public Movement movement;
    WallScript wallScript = null;
    private UpgradeList upgradeList;

// Use this for initialization
    void Start () {
        HPvar.GetComponent<FollowPlayer>().Player = this.gameObject;
        HPvar = Instantiate(HPvar);
        upgradeList = new UpgradeList(new FileLoader().Load());
        movement = GetComponent<Movement>();
        MoveSpeed = movement.MoveSpeed + 0.2f * upgradeList.Speed;
        movement.MoveSpeed = MoveSpeed;
        HP += 5 * upgradeList.HP;
        Damage += 0.5f * upgradeList.Damage;
    }

	// Update is called once per frame
	void Update () {

        transform.GetChild(0).gameObject.SetActive(Camera.main.GetComponent<ButtonEvent>().UseSkill);

        if (HP <= 0)
        {
            Destroy(HPvar);
            Camera.main.GetComponent<MainGame>().DeleteUnit(transform.parent.gameObject);
            Camera.main.GetComponent<SpawnWall>().KillCount++;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            Destroy(collision.gameObject);
            HP -= bullet.callme.Damage;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (collision.gameObject.GetComponent<WallScript>().AddUnit(gameObject))
            {
                wallScript = collision.gameObject.GetComponent<WallScript>();
                movement.MoveSpeed = 0;
            }
        }
    }

    private void OnDestroy()
    {
        if (wallScript != null) wallScript.DestroyUnit(gameObject);
    }
}
