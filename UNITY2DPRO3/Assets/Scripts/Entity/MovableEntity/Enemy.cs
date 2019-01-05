using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovableEntity {

    float missileDuration = 1;
    public float MaxMissileDration = 1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move(new Vector2(0, -1));
        Shoot();
	}

    void Shoot()
    {
        if (missileDuration < MaxMissileDration)
        {
            missileDuration += Time.deltaTime;
            return;
        }

        missileDuration = 0;

        for (int i = 0; i < 30; i++)
        {
            GameObject obj = ObjectPool.Instance.GetIObj("Prefabs/Missiles/EnemyMissile");
            obj.GetComponent<Missile>()._speed = 3;
            Vector3 pos = transform.GetChild(0).transform.position;
            float angle = 12 * i;
            angle *= Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            obj.GetComponent<Missile>().Init(dir, pos);
        }

        //GameObject prefab = Resources.Load("Prefabs/Missiles/EnemyMissile")
        //    as GameObject;
        //for(int i = 0; i < 30; i++)
        //{
        //    prefab.GetComponent<Missile>()._speed = 3;
        //    Vector3 pos = transform.GetChild(0).transform.position;
        //    float angle = 12 * i;
        //    angle *= Mathf.Deg2Rad;
        //    Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        //    prefab.GetComponent<Missile>().Init(dir, pos);
        //    //prefab.GetComponent<Missile>().acc = 2;
        //    //prefab.GetComponent<Missile>().maxAnglePS = 20;
        //    GameObject missile = Instantiate(prefab);
        //    //missile.GetComponent<Missile>().acc = 2;
        //    //missile.GetComponent<Missile>().maxAnglePS = 20;
        //}
        //missile.transform.parent = transform;
    }
}
