using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour {

    Dictionary<string, BehaviorState> dicStates = new Dictionary<string, BehaviorState>();

    BehaviorState curState;
	// Use this for initialization
	void Start () {
        dicStates.Add("idle",   GetComponent<BehaviorStateIdle>());
        dicStates.Add("attack", GetComponent<BehaviorStateAttack>());
        dicStates.Add("find",   GetComponent<BehaviorStateFind>());
        dicStates.Add("trace",  GetComponent<BehaviorStateTrace>());

        curState = dicStates["idle"];
        curState.onEnter();
    }
    public void run()
    {
        // 현재 state를 확인하고 끝나면 다음 state를 선택해서 실행 - leave, enter호출
        // 현재 state를 확인하고 실행 중이라면 excute
        if(curState == null)
        {
            return;
        }
        if(curState.isEnd())
        {
            curState = dicStates[curState.onLeave()];
            curState.onEnter();
        }
        else
        {
            curState.onExcute();
        }
        

        Debug.Log("play FSM");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
