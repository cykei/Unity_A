using UnityEngine;
using System.Collections;

public class BehaviourStateAttack : BehaviourState
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    override public void onEnter()
    {
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isAttack", true);
            animator.SetBool("isWalk", false);
        }
       
    }

    public override void onExcute()
    {
      

    }

    public override string onLeave()
    {
        string nextState = "idle";
        // 대상을 찾은 경우 nextState를 trace로 변경
        if (target != null)
        {
            nextState = "attack";
        }

        return nextState;
    }

    public override bool isEnd()
    {
        if (target != null)
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
