using UnityEngine;
using System.Collections;

public class BehaviourStateIdle : BehaviourState
{
    // 특정 시간이 지나면 이 STATE를 끝나게 하자.
    public float maxExcuteTime;
    public float playTime;

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
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isAttack", false);
            animator.SetBool("isWalk", true);
        }
        playTime = 0;
    }
    override public void onExcute()
    {
        playTime += Time.deltaTime;
    }
    override public string onLeave()
    {
       // 부모클래스의 onLeave()를 호출한다. base는 c#의 예약어(java의 super)
       // base.onLeave(); // 자동완성기능.

        // 다음 state 가 뭔지 알려준다.
        return "find";
    }

    public override bool isEnd()
    {
        return playTime >= maxExcuteTime;
    }
}
