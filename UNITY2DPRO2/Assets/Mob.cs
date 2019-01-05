using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour {

    public GameObject SwordNode;
    
    Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        SwordNode.SetActive(false);

        /*
        AnimatorStateInfo aniState = ani.GetCurrentAnimatorStateInfo(0);
        AnimatorClipInfo[] AniClip = ani.GetCurrentAnimatorClipInfo(0);
        myTime = AniClip[0].clip.length * aniState.normalizedTime;
        */
    }

    void Start ()
    {

    }

    public void OnSwordEffect()
    {
        SwordNode.SetActive(true);
    }

    public void OffSwordEffect()
    {
        SwordNode.SetActive(false);
    }

    public void AttEnvent_1()
    {
        Debug.Log("AttEnvent_1");
    }

    void Update()
    {
/*        if (Input.GetMouseButtonDown(0))
        {
            ani.SetInteger("AniIndex", 0);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            ani.SetInteger("AniIndex", 2);
        }
*/
    }
}
