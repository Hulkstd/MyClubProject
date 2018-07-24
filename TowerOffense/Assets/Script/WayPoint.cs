using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WayPoint : MonoBehaviour {

    public static Transform[,] points;
    public static int[] count;
    public static int points_count;

    private void Awake()
    {
        if(SceneManager.GetActiveScene().name == "Stage1")
        {
            Load();
        }
    }

    public void Load()
    {
        //points 변수에 2차원배열 크기 선언
        points = new Transform[transform.childCount, 40];
        //points_count 에 points 변수의 행의 갯수 저장
        points_count = transform.childCount;
        //count 배열의 크기 선언
        count = new int[transform.childCount];
        for(int i=0; i<transform.childCount; i++)
        {   //count[i]에 points의 행의 사용하는 길이를 저장
            count[i] = transform.GetChild(i).childCount;
            for(int j=0; j<transform.GetChild(i).childCount; j++)
            {
                //points 에 WayPoint 저장
                points[i, j] = transform.GetChild(i).GetChild(j).transform;
            }
        }
    }
}
