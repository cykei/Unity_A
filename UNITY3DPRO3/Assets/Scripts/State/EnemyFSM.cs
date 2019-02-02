using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyFSM : MonoBehaviour
{
    Dictionary<string, BehaviourState> dicStates;
    BehaviourState curState;
    // Use this for initialization
    void Start()
    {
        dicStates.Add("idle", GetComponent<BehaviourStateIdle>());
        dicStates.Add("attack", GetComponent<BehaviourStateAttack>());
        dicStates.Add("find", GetComponent<BehaviourStateWalk>()); //walk == find
        dicStates.Add("trace", GetComponent<BehaviourStateTrace>());

        curState = dicStates["idle"]; // 현재 스테이트 지정
        curState.onEnter(); // 지정된 스테이트 실행
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void run()
    {
        // 현재 state를 확인하고 끝나면 다음 state를 선택해서 실행 - leave, enter 호출
        // 현재 state를 확인하고 실행중이라면 excute
        if (curState.isEnd())
        {
            curState = dicStates[curState.onLeave()]; //onLeave()의 return 값이 다음 state의 string이라서.
            //이렇게 하면 curState 에 다음 state 가 들어가게된다. 지금은 find
            curState.onEnter();
        }
        else
        {
            curState.onExcute();
        }
        Debug.Log("play FSM");
    }
}
