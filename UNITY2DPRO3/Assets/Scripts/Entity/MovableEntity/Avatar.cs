using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MovableEntity {

    public Controller _controller;

    float missileDuration = 1;

    public float MaxMissileDration = 1;
	// Use this for initialization
	void Start () {
        Debug.Log("Avatar Start");
    }
	// Update is called once per frame
	void Update () {
        if (!GameStateManager.Instance.isPlaying) return;
        Move(_controller.GetDir());
        Shoot();
	}

    void Shoot()
    {
        if(missileDuration < MaxMissileDration)
        {
            missileDuration += Time.deltaTime;
            return;
        }

        if (!_controller.IsShoot()) return;

        missileDuration = 0;

        GameObject obj = ObjectPool.Instance.GetIObj("Prefabs/Missiles/AvatarMissile");
        obj.GetComponent<Missile>()._speed = 5;
        Vector3 pos = transform.GetChild(0).transform.position;
        obj.GetComponent<Missile>().Init(new Vector2(0, 1f), pos);
        //GameObject prefab = Resources.Load("Prefabs/Missiles/AvatarMissile") 
        //    as GameObject;
        //prefab.GetComponent<Missile>()._speed = 5;
        //Vector3 pos = transform.GetChild(0).transform.position;
        //prefab.GetComponent<Missile>().Init(new Vector2(0, 1f), pos);
        //GameObject missile = Instantiate(prefab);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("collision");
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("collision");
    //}
}
