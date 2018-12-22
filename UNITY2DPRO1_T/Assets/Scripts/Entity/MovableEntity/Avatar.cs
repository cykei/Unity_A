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

        GameObject prefab = Resources.Load("Prefabs/Missiles/AvatarMissile") 
            as GameObject;
        prefab.GetComponent<Missile>()._speed = 5;
        Vector3 pos = transform.GetChild(0).transform.position;
        prefab.GetComponent<Missile>().Init(new Vector2(0, 1f), pos);
        GameObject missile = Instantiate(prefab);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
    }

    private void OnTriggerEnter(Collider other)
    {
        //물리엔진을 안써도 되면 이걸 쓰자. 이게 아주 약간이나마 OnCollisionEnter보다 가볍다. 
        //그렇지만 이걸 쓴다고 해서 rigidbody 물리엔진이 안걸리는 건 아니다. 다 걸린다.
        Debug.Log("collision");
    }
}
