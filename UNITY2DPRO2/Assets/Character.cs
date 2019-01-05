using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    Animator ani;

    void Awake()
    {
        ani = GetComponent<Animator>();
    }

    void Start () {
		
	}
	
	void Update () {
        if( Input.GetMouseButtonDown(0) )
        {
            ani.SetInteger("AnyIndex", 1);
        }
        else if( Input.GetMouseButtonDown(1) )
        {
            ani.SetInteger("AnyIndex", 0);
        }
	}
}
