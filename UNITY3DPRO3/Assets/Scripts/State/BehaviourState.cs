using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourState : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    virtual public void onEnter()
    {

    }

    virtual public void onExcute()
    {

    }

    virtual public string onLeave()
    {
        return "";
    }

    virtual public bool isEnd()
    {
        //state 가 종료됐는지 확인 가능한 함수
        return false;
    }
}
