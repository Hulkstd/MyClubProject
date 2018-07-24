using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAI : MonoBehaviour
{

    public Transform target;
    public float range = 15f;
    public GameObject Bullet;
    public float fire_delay = 0.3f;
    public float Damage = 1f;
    public bool DualShoot = true;
    public float Middle_to_Bullet = 0.1f;
    bool spawnpoint = true;
    AudioSource audioSource;
    Quaternion rotation;

    public string PlayerTag = "Player";

    public Transform partToRotate;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.2f); //UpdateTarget 부르는 함수 ("UpdataTarget"을, 0f 초 있다가, 0.2f 간격으로 부른다)
        InvokeRepeating("FireBullet", 0f, fire_delay);
        audioSource = GetComponent<AudioSource>();
    }

    void FireBullet()
    {
        if (target == null)
        {
            return;
        }
        if (!DualShoot)
        {
            Bullet.GetComponent<Bullet>().callme = this;
            Instantiate(Bullet, new Vector3(partToRotate.transform.position.x, partToRotate.transform.position.y, -0.1f),
                new Quaternion(0, 0, rotation.z, rotation.w));
        }
        else
        {
            Bullet.GetComponent<Bullet>().callme = this;
            if (spawnpoint)
            {
                Instantiate(Bullet, new Vector3(partToRotate.transform.position.x - Middle_to_Bullet, partToRotate.transform.position.y, -0.1f),
                new Quaternion(0, 0, rotation.z, rotation.w));
                spawnpoint = !spawnpoint;
            }
            else
            {
                Instantiate(Bullet, new Vector3(partToRotate.transform.position.x + Middle_to_Bullet, partToRotate.transform.position.y, -0.1f),
                new Quaternion(0, 0, rotation.z, rotation.w));
                spawnpoint = !spawnpoint;
            }
        }

        audioSource.Play();
    }

    void UpdateTarget()
    {
        GameObject[] Players = GameObject.FindGameObjectsWithTag(PlayerTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;

        //가장 가까운곳에 있는 플레이이어를 알아냄
        //이정도의 주석은 괜찮은듯
        foreach (GameObject Player in Players)
        {
            float distance = Vector3.Distance(transform.position, Player.transform.position);

            if (distance < shortestDistance)
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
    void Update()
    {

        if (target == null)
        {
            return;
        }

        rotation = Quaternion.LookRotation
            (target.transform.position - partToRotate.position, partToRotate.TransformDirection(Vector3.back));
        partToRotate.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(partToRotate.transform.position, range);
    }
}
