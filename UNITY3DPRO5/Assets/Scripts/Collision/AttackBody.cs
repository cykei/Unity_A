using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBody : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("attack");

        CollisionDispatcher.instance
            .DispatchCollision(transform.parent.gameObject, other.gameObject);
    }
}
