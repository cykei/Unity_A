using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MovableEntity
{
    public Vector2 dir;
    Vector2 startDir;

    public Vector2 startPos;
    public float acc;

    public float maxAnglePS;

    float angle = 0;

	// Use this for initialization
	void Start () {
        transform.position = startPos;
    }

    public void Init(Vector2 dir, Vector2 pos)
    {
        angle = 0;
        this.dir = dir;
        startPos = pos;
        startDir = dir;
        transform.position = startPos;
    }
	
	// Update is called once per frame
	void Update () {
        UpdateSpeed();
        UpdateDir();
        Move(dir);
	}

    void UpdateDir()
    {
        if (maxAnglePS == 0) return;
        angle += Time.deltaTime * maxAnglePS;
        this.dir = startDir + new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad),
                                Mathf.Sin(angle* Mathf.Deg2Rad));
    }

    void UpdateSpeed()
    {
        _speed += acc*Time.deltaTime;
    }
}
