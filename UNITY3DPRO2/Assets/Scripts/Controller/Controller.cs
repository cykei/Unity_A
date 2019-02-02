using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    // 이놈은 이제 Avatar와 KeyboardController등의 중간매개자.
    // 이걸 이용해서 Avatar에게 계산결과를 알린다.

    protected Vector3 _dir = Vector3.zero;
    protected bool isAttack = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public Vector3 GetDir()
    {
        return _dir;
    }


    public bool IsAttack()
    {
        return isAttack;
    }

    public void DisableAttack()
    {
        isAttack = false;
    }
}
