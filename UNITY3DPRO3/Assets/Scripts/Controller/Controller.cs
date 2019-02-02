using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    protected Vector3 _dir = Vector3.zero;
    protected bool isAttack = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 GetDir()
    {
        return _dir;
    }

    public bool IsAttack()
    {
        return isAttack;
    }
    public void DisableAttack()
    {
        isAttack = false;
    }
}
