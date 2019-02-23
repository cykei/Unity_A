using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : Entity {

    public Controller controller;
    public Camera mainCamera;

	// Use this for initialization
	void Start () {
        bv = new BattleValue(100, 10, 2);
	}
	
	// Update is called once per frame
	void Update () {
        CalcDir();
        UpdateAnimation();
        Move();
	}

    override public void Move()
    {
        if (!controller.IsAttack())
        {
            //transform.Translate(_dir.normalized * speed * Time.deltaTime);
            transform.parent.Translate(_dir.normalized * speed * Time.deltaTime);
            Vector3 pos = mainCamera.transform.position;
            pos += _dir.normalized * speed * Time.deltaTime;
            mainCamera.transform.position = pos;
        }
    }


    void CalcDir()
    {
        _dir = controller.GetDir();
        _dir.x *= -1;
        if(_dir.Equals(Vector3.zero))
        {
            return;
        }

        /*
        Vector3 fromV = new Vector3(0, 0, 1);
        transform.rotation =
            Quaternion.AngleAxis(Vector3.Angle(fromV, _dir), new Vector3(0, 1, 0));
        */
      
        Quaternion newRotation = Quaternion.LookRotation(_dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, speed * Time.deltaTime);
        
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
