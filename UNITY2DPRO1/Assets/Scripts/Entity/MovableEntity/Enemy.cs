using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovableEntity {


    public Vector2 dir;
    public Vector2 startPos;
    public float acc;
    public float maxAnglePS;


    // Use this for initialization
    void Start()
    {
        // 이 객체가 씬에 붙을때 Start가 호출이된다.
        transform.position = startPos;
    }

    public void Init(Vector2 dir, Vector2 pos)
    {
        this.dir = dir;
        startPos = pos;
    }
    /*
    // Update is called once per frame
    void Update()
    {
        // 이동을 하고 계산을 해줘야한다.

        UpdateSpeed();
        UpdateDir();
        Move(dir); // dir방향으로 이동
    }
    */
    void UpdateDir()
    {

    }

    void UpdateSpeed()
    {
        _speed += acc * Time.deltaTime;

    }
}
