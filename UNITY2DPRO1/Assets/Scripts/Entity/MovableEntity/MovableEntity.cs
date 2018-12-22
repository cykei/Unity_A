using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableEntity : Entity {

    public float _speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move(Vector2 v)
    {
        // v == 방향
        Vector2 calcedV = v.normalized * _speed * 0.01f; 
        // 방향을 normalized 해서 속도를 곱해줘야 대각선으로 가도 동일한 속도 유지 가능. 옛날게임 보면 대각선만 빨리 움직이는게 있거든.
        // _speed 가 정수인게 좋으니까 0.01을 곱해준다.

        transform.Translate(calcedV);
        // Translate() : 받은 벡터만큼 이동을 한다.
    }
}
