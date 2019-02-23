using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {

    IEnumerator destroyEffect()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this);
    }

	
	// Update is called once per frame
	void Update () {
        StartCoroutine("destroyEffect");
	}
}
