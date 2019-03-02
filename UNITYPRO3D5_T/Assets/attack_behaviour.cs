﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_behaviour : StateMachineBehaviour {

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.SetBool("isAttack", false);
        // 여기서 controller의 isAttack값을 false로 처리
        GameObject obj = animator.gameObject;
        int childCount = obj.transform.childCount;
        for(int i = 0; i < childCount; i++)
        {
            Transform child = obj.transform.GetChild(i);
            if (child.name.Equals("Attack_body"))
            {
                child.gameObject.SetActive(true);
            }

        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttack", false);
        GameObject obj = animator.gameObject;
        int childCount = obj.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform child = obj.transform.GetChild(i);
            if (child.name.Equals("Attack_body"))
            {
                child.gameObject.SetActive(false);
            }

        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}