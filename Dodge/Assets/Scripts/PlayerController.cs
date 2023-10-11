using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;        //�̵��� ����� ������ �ٵ� ������Ʈ
    public float speed = 8.0f;               //�̵� �ӷ�

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKey(KeyCode.UpArrow) == true)           //���� ����Ű �Է��� ������ ��� Z ���� ���ֱ�
        //{
        //    playerRigidbody.AddForce(0f, 0f, speed);        //���� ���� == Z��
        //}
        //if (Input.GetKey(KeyCode.DownArrow) == true)           //�Ʒ��� ����Ű �Է��� ������ ��� Z ���� ���ֱ�
        //{
        //    playerRigidbody.AddForce(0f, 0f, -speed);        //�Ʒ��� ���� == Z��
        //}
        //if (Input.GetKey(KeyCode.RightArrow) == true)           //������ ����Ű �Է��� ������ ��� Z ���� ���ֱ�
        //{
        //    playerRigidbody.AddForce(speed , 0f, 0f);        //������ ���� == Z��
        //}
        //if (Input.GetKey(KeyCode.LeftArrow) == true)           //���� ����Ű �Է��� ������ ��� Z ���� ���ֱ�
        //{
        //    playerRigidbody.AddForce(-speed ,0f, 0f);        //���� ���� == Z��
        //}

        float xInput = Input.GetAxis("Horizontal");   //������
        float zInput = Input.GetAxis("Vertical");   //������

        Debug.Log("xInput : " + xInput + ", zInput" + zInput);

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Debug.Log("xInput : " + xInput + ", zInput" + zInput);

        Vector3 newVelocirty = new Vector3(xSpeed, 0f, zSpeed);   //Vector3 �ӵ��� (xSpeed, 0 zSpeed)�� ����
        playerRigidbody.velocity = newVelocirty;  //������ٵ��� �ӵ��� newVelocity �Ҵ�
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
