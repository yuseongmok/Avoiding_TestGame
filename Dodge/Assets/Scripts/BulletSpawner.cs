using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;   //������ ź���� ���� ������
    public float spawnRateMin = 0.5f;  //�ּ� ���� �ֱ�
    public float spawnRateMax = 3.0f;  //�ִ� ���� �ֱ�

    private Transform target;  //�߻��� ���
    private float spawnRate; //���� �ֱ�
    private float timeAfterSpawn;  //�ֱ� ���� �������� ���� �ð�

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0.0f; //�ֽ� ���� ������ ���� �ð��� 0�ʷ� �ʱ�ȭ

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);  //Ÿ�� ���� ������ ���� ����
        //PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���� ������� ����
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;           //timeAfterSpawn
        //�ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
        if (timeAfterSpawn >= spawnRate)
        {
            //������ �ð��� ����
            timeAfterSpawn = 0.0f;

            this.gameObject.transform.LookAt(target, Vector3.up);      //�����ʰ� �÷��̾ ���ϰ�
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation); //Bullet �������� ����
            bullet.transform.LookAt(target);        //������ Bullet�� ������ target�� ���ϵ���
            //������ ���� ������ ���� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }

    }
}
