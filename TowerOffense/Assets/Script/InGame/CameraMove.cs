using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour {

    public float OriginalSize;
    Image UIImage;
    public Vector3 leftUp;
    public Vector3 leftDown;
    public Vector3 rightUp;
    public Vector3 rightDown;
    public Vector3 origin;

	// Use this for initialization
	void Start () {
        UIImage = GameObject.Find("SpawnUI").GetComponent<Image>();

        leftUp = Camera.main.ScreenToWorldPoint(new Vector3(UIImage.canvas.transform.position.x - UIImage.canvas.pixelRect.width / 2, 
                                                            UIImage.canvas.transform.position.y + UIImage.canvas.pixelRect.height / 2));

        leftDown = Camera.main.ScreenToWorldPoint(new Vector3(UIImage.canvas.transform.position.x - UIImage.canvas.pixelRect.width / 2,
                                                            UIImage.canvas.transform.position.y - UIImage.canvas.pixelRect.height / 2));

        rightUp = Camera.main.ScreenToWorldPoint(new Vector3(UIImage.transform.position.x - UIImage.rectTransform.rect.width / 2,
                                                            UIImage.canvas.transform.position.y + UIImage.canvas.pixelRect.height / 2));

        rightDown = Camera.main.ScreenToWorldPoint(new Vector3(UIImage.transform.position.x - UIImage.rectTransform.rect.width / 2,
                                                            UIImage.canvas.transform.position.y - UIImage.canvas.pixelRect.height / 2));

        OriginalSize = Camera.main.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.mouseScrollDelta.y;
        if(x < 0)
        {
            Camera.main.orthographicSize += 1.0f;
        }
        else if(x > 0)
        {
            Camera.main.orthographicSize -= 1.0f;
        }

        if (Camera.main.orthographicSize > OriginalSize)
        {
            Camera.main.orthographicSize = OriginalSize;
        }

        if (Camera.main.orthographicSize < 10)
        {
            Camera.main.orthographicSize = 10;
        }

        Vector3 nowLeftUp, nowRightDown;

        nowLeftUp = Camera.main.ScreenToWorldPoint(new Vector3(UIImage.canvas.transform.position.x - UIImage.canvas.pixelRect.width / 2,
                                                            UIImage.canvas.transform.position.y + UIImage.canvas.pixelRect.height / 2));

        nowRightDown = Camera.main.ScreenToWorldPoint(new Vector3(UIImage.transform.position.x - UIImage.rectTransform.rect.width / 2,
                                                            UIImage.canvas.transform.position.y - UIImage.canvas.pixelRect.height / 2));

        if (nowRightDown.x > rightDown.x)
        {
            transform.position = new Vector3(transform.position.x - (nowRightDown.x - rightDown.x), transform.position.y, -10);
        }  // 잘됨

        if (nowLeftUp.x < leftDown.x)
        {
            transform.position = new Vector3(transform.position.x - (nowLeftUp.x - leftDown.x), transform.position.y, -10);
        }

        if (nowLeftUp.y > rightUp.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (nowLeftUp.y - rightUp.y), -10);
        }

        if (nowRightDown.y < rightDown.y)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y - (nowRightDown.y - rightDown.y), -10);
        }

        if (Input.GetMouseButtonDown(0))
        {
            origin = Input.mousePosition;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 vec = Camera.main.WorldToViewportPoint(origin - Input.mousePosition);
        Vector3 move = vec.normalized;
        move.z = 0;

        transform.Translate(move);

        
    }
    

}
