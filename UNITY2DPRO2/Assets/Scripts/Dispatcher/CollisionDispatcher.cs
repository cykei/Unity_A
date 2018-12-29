using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDispatcher : MonoBehaviour {

    private static CollisionDispatcher _instance;
    public static CollisionDispatcher Instance
    {
        get
        {
            if(!_instance)
            {
                _instance = GameObject.FindObjectOfType(typeof(CollisionDispatcher)) as CollisionDispatcher;
                if(!_instance)
                {
                    GameObject container = new GameObject();
                    container.name = "CollisionDispatcher";
                    _instance = container.AddComponent(typeof(CollisionDispatcher)) as CollisionDispatcher;

                }
            }
            return _instance;
        }
    }

    public void TEST()
    {

    }
    //public static CollisionDispatcher Instance;

    //public void Awake()
    //{
    //    CollisionDispatcher.Instance = this;
    //}
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Dispatch(CollisionManager.CollisionObj collision)
    {
        CollisionManager.Instance.PushCollisionObj(collision);
    }
}
