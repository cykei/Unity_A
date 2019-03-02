using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {

    private EnemyFSM enemyFSM;
    public GameObject namePlate;

    // Use this for initialization
    void Start () {
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
    void GenerateNamePlate()
    {
        GameObject nameP = Instantiate(namePlate);
        nameP.SetActive(true);

    }
}
