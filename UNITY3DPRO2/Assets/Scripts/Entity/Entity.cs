using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    // 모든 객체들이 이동을 가능하게 할거임. 
    // 이동의 기본요소는 방향과 속도.
    protected Vector3 _dir =Vector3.zero;
    public float speed = 0;
	
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    public void Move()
    {
        // Entity를 이동시킨다.
        transform.Translate(_dir.normalized * speed * Time.deltaTime);
    }
}
