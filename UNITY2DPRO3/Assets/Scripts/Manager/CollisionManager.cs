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
    List<CollisionObj> collisionLst = new List<CollisionObj>();
    List<GameObject> deleteLst = new List<GameObject>();
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        deleteLst.Clear();
        CalcCollision();
        UpdateObj();
        collisionLst.Clear();
    }

    public void PushCollisionObj(CollisionObj obj)
    {
        bool isNotAdded = true;
        foreach(var item in collisionLst)
        {
            if( (item.collee == obj.collee 
                && item.coller == obj.coller) ||
                (item.collee == obj.coller
                && item.coller == obj.collee) )
            {
                isNotAdded = false;
            }
        }
        //for(int i = 0; i < collisionLst.Count; i++)
        //{
        //    if ((collisionLst[i].collee == obj.collee
        //        && collisionLst[i].coller == obj.coller) ||
        //        (collisionLst[i].collee == obj.coller
        //        && collisionLst[i].coller == obj.collee))
        //    {
        //        isNotAdded = false;
        //    }
        //}
        if(isNotAdded) collisionLst.Add(obj);
    }
    void CalcCollision()
    {
        // 충돌을 계산한다.
        // avatar가 아닌 객체들은 지우는 리스트에 등록
        foreach(var col in collisionLst)
        {
            if (col.collee.tag.Contains("avatar")
               && col.coller.tag.Contains("avatar"))
            {
                continue;
            }
            if (col.collee.tag.Contains("enemy")
                && col.coller.tag.Contains("enemy"))
            {
                continue;
            }
            if (col.collee.tag.Contains("Missile")
                && col.coller.tag.Contains("Missile"))
            {
                continue;
            }
            if (!col.coller.tag.Equals("avatar") )
            {
                if (deleteLst.IndexOf(col.coller) < 0
                    && !col.coller.tag.Equals("edge"))
                {
                    deleteLst.Add(col.coller);
                }
            }
            if(!col.collee.tag.Equals("avatar"))
            {
                if (deleteLst.IndexOf(col.collee) < 0
                    && !col.collee.tag.Equals("edge"))
                {
                    deleteLst.Add(col.collee);
                }
            }

            // 아바타가 enemy나 emenyMissile과 충돌시 게임오버
            if ( (col.coller.tag.Equals("avatar") && col.collee.tag.Contains("enemy"))
                || (col.collee.tag.Equals("avatar") && col.coller.tag.Contains("enemy")) )
            {
                //GameStateManager.Instance.GameOver();
            }
        }
    }
    void UpdateObj()
    {
        //지울 obj들을 지워준다
        foreach(var obj in deleteLst)
        {
            if(obj !=  null && obj.tag.Equals("enemyMissile"))
            {
                ObjectPool.Instance.ReleaseItem(obj, "Prefabs/Missiles/EnemyMissile");
            }
            else if (obj != null && obj.tag.Equals("avatarMissile"))
            {
                ObjectPool.Instance.ReleaseItem(obj, "Prefabs/Missiles/AvatarMissile");
            }
            /*
            else if (obj != null && obj.tag.Equals("enemy"))
            {
                ObjectPool.Instance.ReleaseItem(obj, "Prefabs/Enemys/Enemy");
            }
            */
            else
            {
                Destroy(obj);
            }
            
        }
    }
}
