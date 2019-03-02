using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    
    public class BattleValue
    {
        public float hp;
        public float atk;
        public float def;
        public float maxHp;
        public BattleValue(float hp, float atk, float def)
        {
            maxHp = hp;
            this.hp = hp;
            this.atk = atk;
            this.def = def;
        }
        public static void CalcDamage(BattleValue senderBv, BattleValue receiverBv)
        {
            float atk = senderBv.atk;
            float def = receiverBv.def;
            float hp = receiverBv.hp;
            hp = hp - atk + def;
            receiverBv.hp = hp;
            Debug.Log("hp : " + hp);
        }
    }

    protected Vector3 _dir = Vector3.zero;
    public float speed = 0;

    public BattleValue bv;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    virtual public void Move()
    {
        // Entity를 이동시킨다.
        transform.Translate(_dir.normalized * speed * Time.deltaTime);
    }

    
}
