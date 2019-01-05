using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    class itemPool
    {
        class item
        {
            public GameObject obj;
            public bool isUsing = false;
        }
        List<item> itemList = new List<item>();
        public string path = "";
        public itemPool(string path, int count)
        {
            this.path = path;
            for (int i = 0; i < count; i++)
            {
                AddItem();
            }
        }
        void AddItem()
        {
            GameObject prefab = Resources.Load(path) as GameObject;
            GameObject obj = Instantiate(prefab);
            item item = new item();
            item.obj = obj;
            itemList.Add(item);
            obj.SetActive(false);
        }
        public void ReleaseItem(GameObject obj)
        {
            foreach (var item in itemList)
            {
                if (obj == item.obj)
                {
                    item.obj.transform.position = Vector3.zero;
                    item.obj.SetActive(false);
                    item.isUsing = false;
                }
            }
        }
        public GameObject GetItemObj()
        {
            foreach (var item in itemList)
            {
                if (!item.isUsing)
                {
                    item.isUsing = true;
                    item.obj.SetActive(true);
                    return item.obj;
                }
            }
            AddItem();
            return GetItemObj();
        }
    }
    private static ObjectPool _instance;
    public static ObjectPool Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = GameObject.FindObjectOfType(typeof(ObjectPool)) as ObjectPool;
                if (!_instance)
                {
                    GameObject container = new GameObject();
                    container.name = "ObjectPool";
                    _instance = container.AddComponent(typeof(ObjectPool)) as ObjectPool;

                }
            }
            return _instance;
        }
    }

    Dictionary<string, itemPool> dict = new Dictionary<string, itemPool>();
    // Use this for initialization
    void Start()
    {
        PreLoad();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PreLoad()
    {
        //미리 오브젝트들을 로딩 및 생성해서 들고 있는다.
        dict.Add("Prefabs/Missiles/EnemyMissile", new itemPool("Prefabs/Missiles/EnemyMissile", 200));
        dict.Add("Prefabs/Missiles/AvatarMissile", new itemPool("Prefabs/Missiles/AvatarMissile", 10));
        //dict.Add("Prefabs/Enemys/Enemy", new itemPool("Prefabs/Enemys/Enemy", 10));
    }

    public GameObject GetIObj(string path)
    {
        // path에 있는 프리팹을 오브젝트 풀에서 찾아 반환한다.
        itemPool pool = dict[path];
        return pool.GetItemObj();
    }

    public void ReleaseItem(GameObject obj, string path)
    {
        // 입력 받은 오브젝트를 사용 중단한다.
        itemPool pool = dict[path];
        pool.ReleaseItem(obj);
    }
}
