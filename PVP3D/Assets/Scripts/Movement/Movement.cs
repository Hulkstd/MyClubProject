using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float Speed;
    public float JumpValue;
    public float RunSpeed;

    public bool IsOnGround;

    public Rigidbody Rig;
    public Camera Cam;
    public Animation Anim;
    public KeyCode[] MoveKey;
    public Vector3[] MoveDir;
    public KeyCode JumpKey;

    public virtual void Move()
    {
        Vector3 dir = Vector3.zero;
        
        for(int i=0; i<MoveKey.Length; i++)
        {
            if(Input.GetKey(MoveKey[i]))
            {
                dir += transform.TransformDirection(MoveDir[i]);
            }
        }

        Rig.AddForce(dir.normalized * Speed,ForceMode.Impulse);

        float speed;
        speed = new Vector3(Rig.velocity.x, 0, Rig.velocity.z).magnitude;

        if(speed > 10.0f)
        {
            float jumpV = Rig.velocity.y;
            Rig.velocity = new Vector3(Rig.velocity.x, 0, Rig.velocity.z).normalized * 10.0f;
            Rig.velocity += new Vector3(0, jumpV, 0);
        }
    }

    public virtual void Jump()
    {
        if(Input.GetKeyDown(JumpKey) && IsOnGround)
        {
            Rig.AddForce(Vector3.up * JumpValue, ForceMode.Impulse);
            IsOnGround = false;
        }
    }

    public void CollisionOnGround(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            IsOnGround = true;
        }
    }
}
