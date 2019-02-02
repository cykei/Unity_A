using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {

    private EnemyFSM enemyFSM;
	// Use this for initialization
	void Start () {
        enemyFSM = GetComponent<EnemyFSM>();
    }
	
	// Update is called once per frame
	void Update () {
        enemyFSM.run();
    }
}
