using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8.0f;            //탄알 이동속력
    private Rigidbody bulletRigidbody;    //이동에 사용할 리지드바디

    private void OnTriggerEnter(Collider other) //트리거 충돌 시 자동으로 실행되는 메서드
    {
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>(); //상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져오기

            if(playerController != null) //상대방으로부터 PlayerController 컴포넌트를 가져오는 데 성공했다면
            {
                playerController.Die(); //상대방 PlayerController 컴포넌트의 Die() 메서드 실행
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //게임 오브젝트에서 RigidBody 컴포넌트를 찾아서 BulletRigidbody 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        //리지드 바디 속도 = 앞쪽방향 * 이동속력
        bulletRigidbody.velocity = transform.forward * speed;

        //3초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
