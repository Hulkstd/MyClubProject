using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAI : MonoBehaviour {

    public Transform target;
    public float range = 15f;
    public GameObject Bullet;

    public string PlayerTag = "Player";

    public Transform partToRotate;

	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); //UpdateTarget 부르는 함수 ("UpdataTarget"을, 0f 초 있다가, 0.5f 간격으로 부른다)
	}
	
    //함수를 만들기는 했는데 호출하는부분이 없음?
    //혹시 실수는 아닌지 확인해보셈
    void UpdateTarget()
    {
        GameObject[] Players = GameObject.FindGameObjectsWithTag(PlayerTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;

        //가장 가까운곳에 있는 플레이이어를 알아냄
        //이정도의 주석은 괜찮은듯
        foreach ( GameObject Player in Players)
        {
            float distance = Vector3.Distance(transform.position, Player.transform.position);
            
            if(distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestPlayer = Player;
            }
        }

        if (nearestPlayer != null && shortestDistance <= range)
        {
            target = nearestPlayer.transform;
        }
        else
        {
            target = null;
        }
    }

	// Update is called once per frame
	void Update () {

        if(target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;

        float z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //partToRotate가 null이라고 함 해결할 필요가 있을듯 (고침)
        partToRotate.rotation = Quaternion.AngleAxis(z - 75, Vector3.forward);

        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, 0) , Quaternion.AngleAxis(z - 75, Vector3.forward));
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
