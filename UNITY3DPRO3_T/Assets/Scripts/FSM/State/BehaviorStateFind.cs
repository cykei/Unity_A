using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 대상을 찾는다.
// 3초정도 탐색을 해도 못찾으면 idle상태로 변경
// 대상을 찾은 경우 trace상태로 변경
public class BehaviorStateFind : BehaviorState
{
    float playTime;
    float findTIme = 3f;
    float area = 100;
    GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    override public void onEnter()
    {
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isAttack", false);
            animator.SetBool("isWalk", false);
        }
        playTime = 0;
        target = null;
    }

    public override void onExcute()
    {
        playTime += Time.deltaTime;
        GameObject avatar = GameObject.Find("UD_demo_character");

        // 특정 조건이 맞다면
        // target에 avatar를 대입
        Vector3 posAvatar = avatar.transform.position;
        Vector3 pos = transform.position;

        if( (posAvatar-pos).sqrMagnitude < area )
        {
            target = avatar;
        }

        // 대상 찾기
    }

    public override string onLeave()
    {
        string nextState = "idle";
        // 대상을 찾은 경우 nextState를 trace로 변경
        if(target != null)
        {
            nextState = "trace";
        }

        return nextState;
    }

    public override bool isEnd()
    {
        // 대상을 찾은경우 true 리턴
        if(target != null)
        {
            return true;
        }
        return playTime >= findTIme;
    }
}
