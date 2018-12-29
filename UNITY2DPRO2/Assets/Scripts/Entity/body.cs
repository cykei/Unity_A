using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class body : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CollisionDispatcher.Instance.TEST();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");

        // collision dispacher 를 통해 collision manager 에 collision 데이터를 저장
        // 근데 이 collision 이라는 애가 생각보다 정보를 많이 갖고 있다.

        // body는 나의 부모 오브젝트(==Avatar)가 무엇인지 알고 있어야한다.
        GameObject parent = transform.parent.gameObject;

        // collision은 나랑 충돌한 애의 콜라이더가 들어온다. 즉, collision은 날아 충돌한 아이의 body이다.
        // 하지만 우리는 객체간의 충돌연산을 해줘야 하니까 나랑 충돌한 아이의 바디의 부모를 가져온다.
        GameObject collee = collision.transform.parent.gameObject;
        CollisionDispatcher.Instance.Dispatch(new CollisionManager.CollisionObj(parent,collee));

    
    }
}
