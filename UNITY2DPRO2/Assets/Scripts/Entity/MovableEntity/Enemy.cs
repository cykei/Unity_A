using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovableEntity {

    Vector3 pos;
    // Use this for initialization
	void Start () {
        pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= pos.y - 5)
        {
            Destroy(this);
        }

        Move(new Vector2(0, -1));
        
	}
}
