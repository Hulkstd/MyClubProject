using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGame : MonoBehaviour {
    public GameObject PauseList;
    private Text Text_Money;
    private bool isGamePaused;
    private bool isGameEnd;
    private List<GameObject> units;
    private List<GameObject> towers;
    private int money;
    private int totalMoney;
    private UpgradeList upgradeList;

    public bool IsGamePaused {
        get { return isGamePaused; }
        set {
            isGamePaused = value;
            if (value) {
                //게임 일시정지일때 할 것들
                //UI보이기 , 일시 정지
                PauseList.SetActive(true);

                Time.timeScale = 0; //일시정지
            }
            else{
                //일시정지 풀릴때
                //UI숨기기 , 시간흐르게 하기
                PauseList.SetActive(false);

                Time.timeScale = 1; //시간흐르게하기
            }
        }
    }

    public bool IsGameEnd {
        get { return isGameEnd; }
        set {
            isGameEnd = value;
            if(isGameEnd) {
                //게임종료시 내용
                PauseList.SetActive(true);

                PauseList.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    public List<GameObject> Units { 
        get {
            return units;
        }
    }

    public GameObject AddUnit(int unitType) {
        //유닛 타입에 따른 유닛 생성
        //그외에 돈 빼는거라던가 기타 등등

        if(Money < unitType * 100)
        {
            return null;
        }

        GameObject unit = Instantiate(Resources.Load("Prefab/PlayerPrefabs/PlayerLV" + unitType)) as GameObject;
        Money -= unitType * 100;

        //생성한 유닛을 units에 추가

        units.Add(unit);

        //생성한 유닛을 그대로 리턴
        return unit;
    }

    public void DeleteUnit(GameObject unit) {
        //유닛 삭제

		units.Remove(unit);
		Destroy (unit);
    }

    public int Money {
        get {
            return money;
        }
        set {
            money = value;
        }
    }

    public void addMoney(int money) {
        this.money += money;
        this.totalMoney += money;
    }

    public List<GameObject> Towers {
        get {
            return towers;
        }
    }

    public void AddTower(GameObject tower) {
        //들어온 타워를 towers에 추가

        tower.transform.SetParent(GameObject.Find("Towers").transform);
        towers.Add(tower);

    }

    void Start()
    {
        PauseList = GameObject.Find("PauseList").gameObject;

        IsGamePaused = false;
        IsGameEnd = false;
        Text_Money = GameObject.Find("Money").GetComponent<Text>();
        InvokeRepeating("MakeMoney", 0f, 0.5f);
        upgradeList = new UpgradeList(new FileLoader().Load());
        units = new List<GameObject>();
        towers = new List<GameObject>();
    }

    void MakeMoney()
    {
        if (totalMoney >= 10000 + 10000 * upgradeList.Max /* 업그레이드에 따라 총량 +: 10000 * (업그레이드 횟수) */)
        {
            CancelInvoke("MakeMoney");
        }

        addMoney(100 + 20 * upgradeList.GetSpeed /* + 2 * 횟수 */);
    }

    // Update is called once per frame
    void Update () {
        Text_Money.text = Money.ToString() + " $";

        if(!IsInvoking("MakeMoney"))
        {
            if(Money < 100)
            {
                IsGameEnd = true;
            }
        }
	}
}
