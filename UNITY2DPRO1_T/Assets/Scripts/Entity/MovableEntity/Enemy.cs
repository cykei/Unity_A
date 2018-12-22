using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovableEntity
{
    public Vector2 dir;
    public float acc;


    // Use this for initialization
    void Start () {

	}
	
	
    void Update()
    {
        UpdateSpeed();
        Move(dir);
    }

    void UpdateSpeed()
    {
        _speed += acc * Time.deltaTime;
    }
}
