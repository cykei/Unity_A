using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Animator animator;
	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D))
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
        
        /*
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(new Vector3(1, 0, 0)*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime);
        }
        */

        if (Input.GetKey(KeyCode.L))
        {
            animator.SetBool("attack",true);
        }
        else {
            animator.SetBool("attack", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("skill");
        }
    }
}
