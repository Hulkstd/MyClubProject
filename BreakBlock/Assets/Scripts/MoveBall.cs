using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour{
    public Vector2 velocity;

    public Rigidbody2D rig;
    MainGame mainGame;

    // Use this for initialization
    void Start()
    {
        mainGame = Camera.main.GetComponent<MainGame>();
        mainGame.AddBall(gameObject);
        rig = mainGame.GetRigidbody2D(gameObject);
        velocity = mainGame.GetVelocity(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.64f, 2.64f), Mathf.Clamp(transform.position.y, -3.8f, 4.826f), 0);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        velocity = mainGame.GetVelocity(gameObject);

        if(collision.gameObject.tag == "Up")
        {
            // 속력 상하 반전

            rig.velocity = new Vector3(velocity.x, 0 - velocity.y);
            velocity = rig.velocity;
        }

        if (collision.gameObject.tag == "Left" || collision.gameObject.tag == "Right")
        {
            // 속력 좌우 반전

            rig.velocity = new Vector3(0 - velocity.x, velocity.y);
            velocity = rig.velocity;
        }

        if (collision.gameObject.tag == "Floor")
        {
            // 멈추고 첫 게임오브젝트이면 위치 저장, 첫오브젝트가 아닐시 첫오브젝트 위치로 이동
            rig.velocity = Vector2.zero;
            velocity = Vector2.zero;
        }

        mainGame.SetVelocity(gameObject, velocity);

    }
}