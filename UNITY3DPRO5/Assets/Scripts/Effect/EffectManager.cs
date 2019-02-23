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
            GameObject ef = Instantiate(attackEffect, collee.transform);
            StartCoroutine("RemoveEffect", ef);
        }
        
    }

    IEnumerator RemoveEffect(GameObject effect)
    {
        yield return new WaitForSeconds(1.0f);

        Destroy(effect);
    }

    IEnumerator networkImp()
    {
        yield return new WWW("https://naver.com");
    }
}
