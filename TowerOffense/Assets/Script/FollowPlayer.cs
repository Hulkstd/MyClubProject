using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//플레이어 위의 HPBar가 플레이어 따라다니는정도의 코드
public class FollowPlayer : MonoBehaviour {

    public GameObject Player;
    Canvas canvas;
    PlayerScript playerScript;
    Slider slider;
    public float Up;

	// Use this for initialization
	void Start () {
        canvas = GameObject.Find("UI").GetComponent<Canvas>();
        transform.SetParent(canvas.transform);
        playerScript = Player.GetComponent<PlayerScript>();
        slider = this.GetComponent<Slider>();
        slider.maxValue = playerScript.HP;
        slider.value = slider.maxValue;
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = playerScript.HP;
        Vector3 vec = new Vector3(Player.transform.position.x, Player.transform.position.y + Up, -0.1f);
        Vector3 worldvec = Camera.main.WorldToScreenPoint(vec);
        //Debug.Log(worldvec);
        transform.position = worldvec;

    }
}
