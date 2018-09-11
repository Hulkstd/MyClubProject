using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public GameObject[] Targets;
    private float RotateSensitivity = 50.0f;

    public GameObject RotationalAxis;
    public GameObject LeftArrow;
    public GameObject RightArrow;
    public Camera Cam;

    private int Index;
    private GameObject Target;
    private bool isLeft;
    private bool isRight;

    private bool IsLeft
    {
        get
        {
            return isLeft;
        }

        set
        {
            isLeft = value;

            LeftArrow.SetActive(!isLeft);
        }
    }

    private bool IsRight
    {
        get
        {
            return isRight;
        }

        set
        {
            isRight = value;

            RightArrow.SetActive(!isRight);
        }
    }

    // Use this for initialization
    void Start () {
        Index = 0;
        Target = Targets[Index];
        IsLeft = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            RotationalAxis.transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * RotateSensitivity, Space.World);
            RotationalAxis.transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * Time.deltaTime * RotateSensitivity, Space.Self);
        }
        RotationalAxis.transform.position = Vector3.Lerp(RotationalAxis.transform.position, Target.transform.position, 0.2f);
    }

    public void Next()
    {
        if (!IsRight)
        {
            Index++;
            Target = Targets[Index];
            IsLeft = false;
            
            if(Index == Targets.Length-1)
            {
                IsRight = true;
            }
            else
            {
                IsRight = false;
            }
        }
        RotationalAxis.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void Prev()
    {
        if (!IsLeft)
        {
            Index--;
            Target = Targets[Index];
            IsRight = false;

            if(Index == 0)
            {
                IsLeft = true;
            }
            else
            {
                IsLeft = false;
            }
        }
        RotationalAxis.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void Select()
    {
        DontDestroyOnLoad(gameObject);
    }
}
