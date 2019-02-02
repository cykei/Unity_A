using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    protected Vector3 _dir = Vector3.zero;
    public float speed = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    public void Move()
    {
        // Entity를 이동시킨다.
        transform.Translate(_dir.normalized * speed * Time.deltaTime);
    }
}
