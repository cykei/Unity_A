using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {
     class CustomCollision {
        public CustomCollision(GameObject coller, GameObject collee)
        {
            this.coller = coller;
            this.collee = collee;
        }
        public GameObject coller;
        public GameObject collee;
    }
    public static CollisionManager instance = null;

    List<CustomCollision> colLst = new List<CustomCollision>();
    List<GameObject> delLst = new List<GameObject>();

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

    private void LateUpdate()
    {
        // 계산
        foreach(var item in colLst)
        {
            // item 은 하나의 충돌을 의미한다.
            // item.coller, item.collee 를 사용
            // 여기에서 충돌을 의미있게 처리한다.
            //item;

            GameObject coller = item.coller;
            GameObject collee = item.collee;

            // 같은 태그끼리는 계산하지 않는다.
            if(coller.tag.Equals(collee.tag))
            {
                continue;
            }

            try
            {
                Entity.BattleValue collerBv = coller.GetComponent<Entity>().bv;
                Entity.BattleValue colleeBv = collee.GetComponent<Entity>().bv;
                if (colleeBv != null && collerBv != null)
                {
                    Entity.BattleValue.CalcDamage(collerBv, colleeBv);
                }

                if (!collee.tag.Equals("Avatar") && colleeBv.hp <= 0)
                {
                    delLst.Add(collee);
                }
            } 
            catch (Exception e)
            {
                Debug.Log(e.ToString());
            }
           
        }
        int cnt = delLst.Count;
        for(int i = 0; i < cnt; i++)
        {
            Destroy(delLst[cnt - 1 - i]);
        }
        delLst.Clear();
        colLst.Clear();
    }

    public void ReceiveCollision(GameObject coller, GameObject collee)
    {
        colLst.Add(new CustomCollision(coller, collee));
    }
}
