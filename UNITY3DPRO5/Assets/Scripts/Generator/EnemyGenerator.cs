using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    public GameObject prepabEnemy;
    private int enemyCount = 0;
    private int enemyCountMax = 10;
    private float dt = 0;
    private float genTerm = 5.0f;
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
        dt += Time.deltaTime;

        if (dt < genTerm) return;

        dt = 0;

        // 몬스터가 10마리 이하라면 10마리가 될때까지 적절한 위치에 생성

        if(enemyCount < enemyCountMax)
        {
            int genCount = enemyCountMax - enemyCount;
            for (int i = 0; i < genCount; i++)
            {
                GameObject obj = Instantiate(prepabEnemy);
                obj.SetActive(true);
                Transform tran = transform.GetChild(i);
                Vector3 pos = tran.position;
                pos.x += Random.Range(-5f, 5f);
                pos.z += Random.Range(-5f, 5f);
                obj.transform.position = pos;
                enemyCount++;
            }
        }
	}
}
