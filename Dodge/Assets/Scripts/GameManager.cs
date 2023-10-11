using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject spawner;
    public GameObject player;

    public List<GameObject> spawnerList = new List<GameObject>();     //스포너 오브젝트
    public float TotalTime = 0.0f;     //전체 체크 시간
    public float TimeCursor = 10.0f;   //간격 시간 설정 (레벨)\
    public float TimeCursorCheck = 0.0f;  //간격 시간 체크 float

    public int cursor = 0;              //레벨 설정 커서 
    public Transform[] spawnPos;        //레벨 젠 추가 위치

    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = (GameObject)Instantiate(spawner);
        temp.transform.position = spawnPos[cursor].transform.position;
        spawnerList.Add(temp);
        cursor += 1;
    }

    // Update is called once per frame
    void Update()
    {
        TotalTime += Time.deltaTime;            //시간 흐르게 설정
        TimeCursorCheck += Time.deltaTime;

        if(TimeCursorCheck >= TimeCursor)
        {
            TimeCursor = 0.0f;

            if(spawnPos.Length > cursor)
            {
                GameObject temp = (GameObject)Instantiate(spawner);              //스포너를 생성
                spawnerList.Add(temp);                                           //리스트에 스포너 입력
                temp.transform.position = spawnPos[cursor].transform.position;   //받아온 위치로 이동
                cursor += 1;                            //단계 올라감 확인
            }

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(player.activeSelf == false)          //액티브가 되어 있지 않을때
            for(int i = 0; i < spawnerList.Count; i++)          //스포너 리스트를 가져와서
            {
                Destroy(spawnerList[i]);                        //하나씩 파괴
            }
                TotalTime = 0.0f;     //전체 체크 시간
                TimeCursor = 10.0f;   //간격 시간 설정 (레벨)\
                TimeCursorCheck = 0.0f;  //간격 시간 체크 float
            cursor = 0;                 //레벨 설정 커서

            player.SetActive(true);

            GameObject temp = (GameObject)Instantiate(spawner);              //스포너를 생성
            spawnerList.Add(temp);                                           //리스트에 스포너 입력
            temp.transform.position = spawnPos[cursor].transform.position;   //받아온 위치로 이동
            cursor += 1;
        }   
    }
}
