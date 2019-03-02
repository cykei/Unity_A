using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {

    private EnemyFSM enemyFSM;

    // Use this for initialization
    void Start () {
        GameObject plate = ObjectPoolManager.instance.GetItem("namePlate");
        GameObject parent = GameObject.Find("namePlates");
        if(parent != null)
        {
            plate.transform.parent = parent.transform;
        }
        plate.GetComponent<NamePlate>().owner = gameObject;
        enemyFSM = GetComponent<EnemyFSM>();
        bv = new BattleValue(50, 5, 1);
       
	}
	
	// Update is called once per frame
	void Update () {
        enemyFSM.run();

    }

    //override public void Move()
    //{
    //    transform.parent.Translate(_dir.normalized * speed * Time.deltaTime);
    //}
}
