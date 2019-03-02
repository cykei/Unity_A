using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {

    public GameObject attackEffect;
    static private EffectManager instance = null;

    static public EffectManager getInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReceiveCollision(GameObject coller, GameObject collee)
    {
        //Debug.Log("coller: " + coller + " collee: " + collee);
        //if(collee!=coller) 
        if (!collee.tag.Equals(coller.tag))
        {
            //GameObject ef = Instantiate(attackEffect, collee.transform);
            // 오브젝트 풀 이용 버전
            GameObject ef = ObjectPoolManager.instance.GetItem("AttackEffect");
            ef.transform.position = collee.transform.position;
            //StartCoroutine("RemoveEffect", ef);
            StartCoroutine("ReleaseEffect", ef);
        }
        
    }

    IEnumerator ReleaseEffect(GameObject effect)
    {
        yield return new WaitForSeconds(1.0f);
        ObjectPoolManager.instance.ReleaseItem("AttackEffect", effect);
    }

    IEnumerator RemoveEffect(GameObject effect)
    {
        yield return new WaitForSeconds(1.0f);
        ObjectPoolManager.instance.ReleaseItem(effect.name, effect);

        Destroy(effect);
    }

    IEnumerator networkImp()
    {
        yield return new WWW("https://naver.com");
    }
}
