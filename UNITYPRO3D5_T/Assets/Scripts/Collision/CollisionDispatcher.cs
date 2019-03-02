using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDispatcher : MonoBehaviour {

    public static CollisionDispatcher instance = null;

    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DispatchCollision(GameObject coller, GameObject collee)
    {
        CollisionManager.instance.ReceiveCollision(coller, collee);
        EffectManager.getInstance().ReceiveCollision(coller, collee);
    }
}
