using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkEffect : MonoBehaviour {
    float dt = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dt >= 1.0f)
        {
            Destroy(this);
        }
        dt += Time.deltaTime;
    }
}

