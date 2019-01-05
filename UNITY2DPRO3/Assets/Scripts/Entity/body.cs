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
        //Debug.Log("collision");

        // collision dispacher 를 통해 collision manager 에 collision
        // 데이터를 저장

        //나의 부모 오브젝트가 무엇인지 알려줘야한다.
        GameObject parent = transform.parent.gameObject;
        GameObject collee = collision.transform.parent.gameObject;
        CollisionDispatcher
            .Instance.Dispatch(new CollisionManager.CollisionObj(parent,
                                                                collee));
    }
}
