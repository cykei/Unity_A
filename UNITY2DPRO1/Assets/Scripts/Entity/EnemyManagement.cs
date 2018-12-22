using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagement : MonoBehaviour {
    public GameObject pos_1;
    public GameObject pos_2;

    void Start()
    {
        for(int i=0; i<3; i++)
        {
            GenerateEnemy();
        }
        
    }

    void Update()
    {
        
    }

    void GenerateEnemy()
    {
        GameObject prefab = Resources.Load("Prefabs/Enemies/EnemyLV1") as GameObject;
        float posX = Random.Range(pos_1.transform.position.x, pos_2.transform.position.x);
        prefab.transform.position = new Vector3(posX, transform.position.y, 0);
        GameObject obj = Instantiate(prefab);
        obj.transform.position = 
    }
}
