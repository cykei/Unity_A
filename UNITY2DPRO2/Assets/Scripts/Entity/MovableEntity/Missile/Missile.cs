using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MovableEntity
{
    public Vector2 dir;

    public Vector2 startPos;
    public float acc;

    public float maxAnglePS;

	// Use this for initialization
	void Start () {
        transform.position = startPos;
    }

    public void Init(Vector2 dir, Vector2 pos)
    {
        this.dir = dir;
        startPos = pos;
    }
	
	// Update is called once per frame
	void Update () {
        UpdateSpeed();
        UpdateDir();
        Move(dir);
	}

    void UpdateDir()
    {

    }

    void UpdateSpeed()
    {
        _speed += acc*Time.deltaTime;
    }
}
