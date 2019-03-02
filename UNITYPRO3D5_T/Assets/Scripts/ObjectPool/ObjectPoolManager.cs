using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour {

    public GameObject[] prefabs;
    public static ObjectPoolManager instance = null;

    Dictionary<string, ObjectPool> dictObjPool = new Dictionary<string, ObjectPool>();

    class ObjectPool
    {
        private GameObject prefab;
        class ItemObj
        {
            public GameObject item;
            public bool isUsed = false;
            public ItemObj(GameObject obj)
            {
                item = obj;
            }
        };
        private List<ItemObj> objList = new List<ItemObj>();
        //public ObjectPool(string path, string key)
        //{

        //}
        public ObjectPool(GameObject obj, string key)
        {
            prefab = obj;
            
            for (int i = 0; i < 20; i++)
            {
                GameObject newGameObj = Instantiate(obj);
                newGameObj.SetActive(false);
                ItemObj newItem = new ItemObj(newGameObj);
                objList.Add(newItem);
            }
        }

        public GameObject GetItem()
        {
            GameObject ret = null;
            foreach(var item in objList)
            {
                if(!item.isUsed)
                {
                    ret = item.item;
                    item.isUsed = true;
                    break;
                }
            }
            if(ret == null)
            {
                ItemObj newItem = new ItemObj(Instantiate(prefab));
                objList.Add(newItem);
                newItem.isUsed = true;
                ret = newItem.item;
            }
            ret.SetActive(true);
            return ret;
        }

        public void ReleaseItem(GameObject obj)
        {
            foreach (var item in objList)
            {
                if(item.item == obj)
                {
                    item.isUsed = false;
                    item.item.SetActive(false);
                    break;
                }
            }
        }
    }

    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
        dictObjPool.Add("AttackEffect", new ObjectPool(prefabs[0], "AttackEffect"));
        dictObjPool.Add("namePlate", new ObjectPool(prefabs[1], "namePlate"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject GetItem(string key)
    {
        return dictObjPool[key].GetItem();
    }

    public void ReleaseItem(string key, GameObject obj)
    {
        dictObjPool[key].ReleaseItem(obj);
    }
}
