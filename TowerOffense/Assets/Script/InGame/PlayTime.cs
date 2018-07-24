using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTime : MonoBehaviour {

    public float playTime;
    public Text timer;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        playTime -= Time.deltaTime;

        string time;

        if(playTime >= 60f)
        {
            time = ((int)(playTime / 60f)).ToString() + " : " +((int)(playTime % 60f)).ToString();
        }
        else
        {
            time = ((int)(playTime % 60f)).ToString();
        }

        timer.text = time.ToString();
	}
}
