using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorStateTrace : BehaviorState
{
    
    float area = 100;
    float attackArea = 0.1f;
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
            animator.SetBool("isIdle", false);
            animator.SetBool("isAttack", false);
            animator.SetBool("isWalk", true);
        }
        GameObject avatar = GameObject.Find("UD_demo_character");
        target = avatar;
    }

    public override void onExcute()
    {
        if(target == null)
        {
            return;
        }
        // 특정 조건이 맞다면
        // target에 avatar를 대입
        Vector3 posAvatar = target.transform.position;
        Vector3 pos = transform.position;

        if ((posAvatar - pos).sqrMagnitude > area)
        {
            target = null;
        }

        //대상을 향해서 이동

        Vector3 moveVector = (pos - posAvatar).normalized;
        moveVector.y = 0;
        moveVector *= Time.deltaTime;
        moveVector *= GetComponent<Enemy>().speed;
        moveVector *= -1;
        
        transform.Translate(moveVector);

    }

    public override string onLeave()
    {
        string nextState = "idle";
        // 대상을 찾은 경우 nextState를 trace로 변경
        if(target != null)
        {
            nextState = "attack";
        }

        return nextState;
    }

    public override bool isEnd()
    {
        if(target != null)
        {
            Vector3 posAvatar = target.transform.position;
            Vector3 pos = transform.position;

            if ((posAvatar - pos).sqrMagnitude < attackArea)
            {
                return true;
            }
        }
        

        return target == null;
    }
}
