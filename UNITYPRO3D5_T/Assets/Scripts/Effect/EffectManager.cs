using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {

    static private EffectManager instance = null;

    public GameObject effect;


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
        // 이팩트 생성
        if (coller.tag.Equals(collee.tag))
        {
            return;
        }

        //GameObject ef = Instantiate(effect);
        //ef.SetActive(true);
        //ef.transform.position = collee.transform.position;
        //StartCoroutine("RemoveEffect", ef);

        GameObject ef = ObjectPoolManager.instance.GetItem("AttackEffect");
        ef.transform.position = collee.transform.position;
        StartCoroutine("ReleaseEffect", ef);
    }

    IEnumerator ReleaseEffect(GameObject effect)
    {
        yield return new WaitForSeconds(1.0f);
        ObjectPoolManager.instance.ReleaseItem("AttackEffect", effect);
    }

    IEnumerator RemoveEffect(GameObject effect)
    {
        yield return new WaitForSeconds(1.0f);

        Destroy(effect);
    }

    IEnumerator networkTmp()
    {
        yield return new WWW("https://naver.com");

        //yield return new AsyncOperation();
    }
}
