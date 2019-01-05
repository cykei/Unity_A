using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableEntity : Entity {
    public float _speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move(Vector2 v)
    {
        Vector2 calcedV = v.normalized * _speed * 0.01f;
        transform.Translate(calcedV);
    }
}
