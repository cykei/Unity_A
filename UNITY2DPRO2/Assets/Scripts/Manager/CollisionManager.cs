using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {
    public class CollisionObj
    {
        public GameObject coller;
        public GameObject collee;
        public CollisionObj(GameObject coller, GameObject collee)
        {
            this.coller = coller;
            this.collee = collee;
        }
    }
    private static CollisionManager _instance;
    public static CollisionManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = GameObject.FindObjectOfType(typeof(CollisionManager)) as CollisionManager;
                if (!_instance)
                {
                    GameObject container = new GameObject();
                    container.name = "CollisionMgr";
                    _instance = container.AddComponent(typeof(CollisionManager)) as CollisionManager;

                }
            }
            return _instance;
        }
    }

    List<CollisionObj> collisionList = new List<CollisionObj>();
    List<GameObject> deleteList = new List<GameObject>();
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CalcCollision(); // 계산다하고
        UpdateObj(); //업데이트하고 
        collisionList.Clear(); // 지운다.
	}

    public void PushCollisionObj(CollisionObj obj)
    {
        bool isNotAdded = true;
        foreach(var item in collisionList)
        {
            if((item.collee == obj.collee && item.coller == obj.coller)||
                (item.collee == obj.coller && item.coller == obj.collee))
            {
                isNotAdded = false;
            }
        }
        /*
        for(int i=0; i<collisionList.Count; i++)
        {
            if((collisionList[i].collee == obj.collee && collisionList[i].coller == obj.coller)||
                (collisionList[i].collee == obj.coller && collisionList[i].coller == obj.collee))
            {
                isNotAdded = false;
            }
        }
        */
        if(isNotAdded) collisionList.Add(obj);
    }

    public void CalcCollision()
    {
        // 충돌을 계산한다. => 나말고 다른 것들 다 deleteList에 등록
        for(int i=0; i<collisionList.Count; i++)
        {
            if (!collisionList[i].collee.tag.Equals("Avatar") && deleteList.IndexOf(collisionList[i].collee)< 0)
            {
                deleteList.Add(collisionList[i].collee);
                // IndexOf :  deleteList에 collee가 있으면 인덱스를 반환해준다. 없으면 -1 이 반환되겠지?
            }
            if (!collisionList[i].coller.tag.Equals("Avatar") && deleteList.IndexOf(collisionList[i].coller) < 0)
            {
                deleteList.Add(collisionList[i].coller);
            }
        }
        
    }
    public void UpdateObj()
    {
        // 지울 obj들을 지워준다.
        foreach(var obj in deleteList)
        {
            Destroy(obj);
            // 왠만하면 뒤에서부터 지워주는게 좋긴하지만 지금 로직에서는 별상관없으니깐.
        }

    }
}
