using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : Controller{

    public GameObject Stick;
    private bool isEnableControll = false;
    private Vector3 startPos = Vector3.zero;
    private Vector2 defaultPos = new Vector2(50, 50);
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            // 1. 유효한 터치 시작 범위를 눌렀는지 판단

            Debug.Log(Input.mousePosition);
            startPos = Input.mousePosition;
            if (Input.mousePosition.x >= 45 && Input.mousePosition.x <= 150
                && Input.mousePosition.y >= 50 && Input.mousePosition.y <= 150)
            {
                isEnableControll = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // 3. dir값을 0으로 초기화
            isEnableControll = false;
            _dir = Vector3.zero;
            RectTransform rtf = Stick.GetComponent<RectTransform>();
            if (rtf != null)
            {
                rtf.anchoredPosition = defaultPos;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            // 2. 유효한 터치 시작 범위를 눌렀는지 판단 됐다면 마우스가 움직인 방향을 계산해서
            // _dir값을 변환
            if (isEnableControll)
            {
                _dir = Input.mousePosition - startPos;
                _dir.z = _dir.y;
                _dir.y = 0;
                RectTransform rtf = Stick.GetComponent<RectTransform>();
                if (rtf != null)
                {
                    Vector2 pos = rtf.anchoredPosition;
                    if (Input.mousePosition != null)
                    {
                        if (pos.x <= 110 && pos.y <= 110 && pos.x>=-5 && pos.y>=-5) { 
                        pos += new Vector2(_dir.x , _dir.z ) * Time.deltaTime;
                        rtf.anchoredPosition = pos;
                        }
                     }
                }

            }
        }
        //Touch[] arrTouchs = Input.touches;
        //for(int i = 0; i < arrTouchs.Length; i++)
        //{
        //    Touch touch = arrTouchs[i];
        //    touch.deltaPosition
        //}

    }
}
