using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : Controller {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _dir = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _dir.y += 1; //이게된다니?! ㅇㅁㅇ
            //_dir += new Vector2(1,1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _dir.x -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _dir.y -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _dir.x += 1;
        }
	}


}
