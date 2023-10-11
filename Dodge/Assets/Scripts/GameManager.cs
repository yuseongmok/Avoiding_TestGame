using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject spawner;
    public GameObject player;

    public List<GameObject> spawnerList = new List<GameObject>();     //������ ������Ʈ
    public float TotalTime = 0.0f;     //��ü üũ �ð�
    public float TimeCursor = 10.0f;   //���� �ð� ���� (����)\
    public float TimeCursorCheck = 0.0f;  //���� �ð� üũ float

    public int cursor = 0;              //���� ���� Ŀ�� 
    public Transform[] spawnPos;        //���� �� �߰� ��ġ

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
        TotalTime += Time.deltaTime;            //�ð� �帣�� ����
        TimeCursorCheck += Time.deltaTime;

        if(TimeCursorCheck >= TimeCursor)
        {
            TimeCursor = 0.0f;

            if(spawnPos.Length > cursor)
            {
                GameObject temp = (GameObject)Instantiate(spawner);              //�����ʸ� ����
                spawnerList.Add(temp);                                           //����Ʈ�� ������ �Է�
                temp.transform.position = spawnPos[cursor].transform.position;   //�޾ƿ� ��ġ�� �̵�
                cursor += 1;                            //�ܰ� �ö� Ȯ��
            }

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(player.activeSelf == false)          //��Ƽ�갡 �Ǿ� ���� ������
            for(int i = 0; i < spawnerList.Count; i++)          //������ ����Ʈ�� �����ͼ�
            {
                Destroy(spawnerList[i]);                        //�ϳ��� �ı�
            }
                TotalTime = 0.0f;     //��ü üũ �ð�
                TimeCursor = 10.0f;   //���� �ð� ���� (����)\
                TimeCursorCheck = 0.0f;  //���� �ð� üũ float
            cursor = 0;                 //���� ���� Ŀ��

            player.SetActive(true);

            GameObject temp = (GameObject)Instantiate(spawner);              //�����ʸ� ����
            spawnerList.Add(temp);                                           //����Ʈ�� ������ �Է�
            temp.transform.position = spawnPos[cursor].transform.position;   //�޾ƿ� ��ġ�� �̵�
            cursor += 1;
        }   
    }
}
