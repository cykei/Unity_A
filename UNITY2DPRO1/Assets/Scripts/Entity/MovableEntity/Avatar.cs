using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MovableEntity {

    public KeyboardController _controller;
	// Use this for initialization
	void Start () {
        Debug.Log("Avatar Start");
	}
	
	// Update is called once per frame
	void Update () {
        Move(_controller.GetDir());
	}
}
