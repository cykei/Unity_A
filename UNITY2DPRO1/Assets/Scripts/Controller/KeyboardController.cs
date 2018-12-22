using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : Controller {
    // 나중에 조이스틱 컨트롤러로 바꿔치기 도 가능하게 요렇게 만들어준다 했던 것 같다.

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _dir = Vector2.zero;
        isShoot = false;

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
        if(Input.GetKey(KeyCode.Space))
        {
            isShoot = true;
        }
      
	}


}
