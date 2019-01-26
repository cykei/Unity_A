using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : Controller {
    // W,A,S,D 중 뭘 누르고 있는지 계산해서 Controller에 넘겨주는 클래스

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _dir = Vector3.zero;

		if(Input.GetKey(KeyCode.W))
        {
            _dir.z += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _dir.x -= 1;

        }
        if (Input.GetKey(KeyCode.S))
        {
            _dir.z -= 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _dir.x += 1;
        }
    }

}
