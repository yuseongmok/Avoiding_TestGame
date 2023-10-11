using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;   //생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f;  //최소 생성 주기
    public float spawnRateMax = 3.0f;  //최대 생성 주기

    private Transform target;  //발사할 대상
    private float spawnRate; //생성 주기
    private float timeAfterSpawn;  //최근 생성 시점에서 지난 시간

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0.0f; //최신 생성 이후의 누적 시간을 0초로 초기화

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);  //타알 새성 간격을 랜덤 지정
        //PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;           //timeAfterSpawn
        //최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        if (timeAfterSpawn >= spawnRate)
        {
            //누적된 시간을 리셋
            timeAfterSpawn = 0.0f;

            this.gameObject.transform.LookAt(target, Vector3.up);      //스포너가 플레이어를 향하게
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation); //Bullet 복제본을 생성
            bullet.transform.LookAt(target);        //생성된 Bullet의 방향이 target을 향하도록
            //다음번 생성 간격을 랜덤 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }

    }
}
