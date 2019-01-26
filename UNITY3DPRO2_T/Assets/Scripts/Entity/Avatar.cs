using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : Entity {

    public Controller controller;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CalcDir();
        UpdateAnimation();
        Move();
	}

    void CalcDir()
    {
        _dir = controller.GetDir();
    }

    void UpdateAnimation()
    {
        Animator animator = GetComponent<Animator>();
        if (animator == null) return;

        if (controller.IsAttack())
        {
            animator.SetBool("isAttack", true);
            animator.SetBool("isWalking", false);
            // 여기서 controller의 isAttack값을 false로 처리
            controller.DisableAttack();
        }
        else if (!_dir.Equals(Vector3.zero))
        {
            animator.SetBool("isAttack", false);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isAttack", false);
            animator.SetBool("isWalking", false);
        }
    }

}
