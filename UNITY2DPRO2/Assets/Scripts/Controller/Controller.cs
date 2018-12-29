using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    protected Vector2 _dir = Vector2.zero;
    protected bool isShoot = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector2 GetDir()
    {
        return _dir;
    }

    public bool IsShoot()
    {
        return isShoot;
    }
}
