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
        if (animator == null) return; // 안전한 코드를 위해서
        if (!_dir.Equals(Vector3.zero))
        {
            //즉, 움직이고 있으면
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }


}
