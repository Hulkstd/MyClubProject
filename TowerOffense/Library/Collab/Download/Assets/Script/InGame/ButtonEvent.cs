using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour {

    public Sprite MuteSprite;
    public Sprite SoundSprite;
    public UpgradeList upgradeList;

    public bool UseSkill = false;

	// Use this for initialization
	void Start () {
        upgradeList = new UpgradeList(new FileLoader().Load());
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Pause()
    {
        Camera.main.GetComponent<MainGame>().IsGamePaused = true;
    }

    public void KeepGoing()
    {
        Camera.main.GetComponent<MainGame>().IsGamePaused = false;
    }

    public void Mute()
    {
        if (!AudioListener.pause)
        {
            //볼륨 0 , UI 이미지 전환
            AudioListener.pause = true;

            Image image = GameObject.Find("Mute").GetComponent<Image>();

            image.sprite = MuteSprite;
        }
        else
        {
            AudioListener.pause = false;

            Image image = GameObject.Find("Mute").GetComponent<Image>();

            image.sprite = SoundSprite;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().path);
    }

    public void Home()
    {
        SceneManager.LoadScene("Tile1");
    }

    public void Barrier()
    {
        UseSkill = true;

        StartCoroutine(CoolDown());
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(3f);

        UseSkill = false;
    }

    public void Shop()
    {
        SceneManager.LoadScene(1);
    }
}
