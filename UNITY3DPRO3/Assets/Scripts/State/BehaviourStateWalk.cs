using UnityEngine;
using System.Collections;

// 판단

public class BehaviourStateWalk : BehaviourState
{
    //3초정도 대상을 찾는다. 못찾으면 idle
    //대상을 찾은경우 trace로 ㄱㄱ

    public float maxExcuteTime=3f;
    public float playTime;
    float area = 1;
    //bool isFind=false; //내방식
    GameObject target;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    override public void onEnter()
    {
        playTime = 0;
        target = null;
    }
    override public void onExcute()
    {
        playTime += Time.deltaTime;
        //움직여라.....
        //transform.position += new Vector3(1, 0, 0);
        GameObject avatar = GameObject.Find("UD_demo_chracter"); // 객체의 이름으로 객체를 찾는 방법 == Find

        Vector3 posAvatar = avatar.transform.position;
        Vector3 pos = transform.position;

        if ((posAvatar - pos).sqrMagnitude < area)
        {
            target = avatar;
            //sqrMagnitud : vector 를 스칼라로 바꿔준다. 벡터의 크기.

        }
    }
    override public string onLeave()
    {
        // 다음 state 가 뭔지 알려준다.
        // if (isFind) return "trace";
        string nextState = "idle";
        if (target != null)
        {
            nextState = "trace";
        }
        return nextState;
    }

    public override bool isEnd()
    {
        //if (isFind) return true;
        if (target != null) return true;

        return playTime >= maxExcuteTime;
    }
}
