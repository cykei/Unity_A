using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public GameObject[] prefabs; // 이펙트
    public static ObjectPoolManager instance = null;

    Dictionary<string, ObjectPool> dictObjPool = new Dictionary<string, ObjectPool>();

    class ObjectPool
    {
        private GameObject prefab;
        class ItemObj
        {
            public GameObject item;
            public bool isUsed = false;
            public  ItemObj(GameObject obj)
            {
                item = obj;
            }
        }
        private List<ItemObj> objList = new List<ItemObj>();
        //public ObjectPool(string path, string key)
        //{

        //}
        public ObjectPool(GameObject obj, string key)
        {
            prefab = obj;

            for (int i=0; i < 20; i++)
            {
                //1. 날것을 만든다.
                GameObject newGameObj = Instantiate(obj);
                newGameObj.SetActive(false); //최초생성시에는 안쓰니까 false로 생성

                //2. 클래스를 입혀서 isUsed 속성을 붙인다.
                ItemObj newItem = new ItemObj(newGameObj);

                //3. 관리를 쉽게 하기 위해 아까 클래스를 입힌 객체를 리스트에 넣는다.
                objList.Add(newItem);
            }
        }

        public GameObject GetItem()
        {
            GameObject ret = null;
            foreach(var item in objList)
            {
                if (!item.isUsed)
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
            //순회를 돌면서 같은 오브젝트라고 판단될시 반환한다.
            foreach(var item in objList)
            {
                if (item.item == obj)
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
    void Start()
    {
        foreach(var item in prefabs)
        {
            //dictObjPool.Add(item.name, new ObjectPool(item, item.name));
            dictObjPool.Add("AttackEffect", new ObjectPool(item, "AttackEffect"));
        }
    }

    // Update is called once per frame
    void Update()
    {

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

