using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorStateIdle : BehaviorState
{
    public float maxExcuteTime;
    public float playTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    override public void onEnter()
    {
        Animator animator = GetComponent<Animator>();
        if(animator != null)
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isAttack", false);
            animator.SetBool("isWalk", false);
        }
        playTime = 0;
    }

    public override void onExcute()
    {
        playTime += Time.deltaTime;
    }

    public override string onLeave()
    {
        // 다음 state가 뭔지 return 해주는건 의미가 있을 수 있다.
        return "find";
    }

    public override bool isEnd()
    {
        return playTime >= maxExcuteTime;
    }
}
