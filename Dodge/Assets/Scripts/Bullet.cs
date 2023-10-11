using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8.0f;            //ź�� �̵��ӷ�
    private Rigidbody bulletRigidbody;    //�̵��� ����� ������ٵ�

    private void OnTriggerEnter(Collider other) //Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼���
    {
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>(); //���� ���� ������Ʈ���� PlayerController ������Ʈ ��������

            if(playerController != null) //�������κ��� PlayerController ������Ʈ�� �������� �� �����ߴٸ�
            {
                playerController.Die(); //���� PlayerController ������Ʈ�� Die() �޼��� ����
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //���� ������Ʈ���� RigidBody ������Ʈ�� ã�Ƽ� BulletRigidbody �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();
        //������ �ٵ� �ӵ� = ���ʹ��� * �̵��ӷ�
        bulletRigidbody.velocity = transform.forward * speed;

        //3�� �ڿ� �ڽ��� ���� ������Ʈ �ı�
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
