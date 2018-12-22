using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    public GameObject pos_1;
    public GameObject pos_2;
    public GameObject pos_3;
    public GameObject pos_4;
    public GameObject pos_5;
    public GameObject pos_6;
    public float MaxDuration = 2;
    float duration = 1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(duration < MaxDuration)
        {
            duration += Time.deltaTime;
            return;
        }
        duration = 0;
        for (int i = 0; i < 3; i++)
        {
            GenerateEnemy();
        }
    }

    void GenerateEnemy()
    {
        GameObject prefab = Resources.Load("Prefabs/Enemys/Enemy") as GameObject;
        float posX1 = Random.Range(pos_1.transform.position.x,
                                        pos_2.transform.position.x);
        float posX2 = Random.Range(pos_3.transform.position.x,
                                pos_4.transform.position.x);
        float posX3 = Random.Range(pos_5.transform.position.x,
                                pos_6.transform.position.x);
        float posX = Random.Range(posX1, posX3);
        Vector3 pos = new Vector3(posX, pos_1.transform.position.y, 0);
        GameObject obj = Instantiate(prefab);
        obj.transform.position = pos;
    }
}
