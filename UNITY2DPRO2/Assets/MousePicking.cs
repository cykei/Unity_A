using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePicking : MonoBehaviour {

    Vector3 endPos = Vector3.zero;
    float speed = 1.5f;
    
    // 방향벡터
    Vector3 dir = Vector3.zero;

    void Start ()
    {
        // 이동끝좌표를 내위치로 초기화
        endPos = transform.position;
    }

	
    void RotateDirectly()
    {
        // y값은 생각하지 않는다.
        // 전후좌우의 방향만을 고려하겠다는 의미
        dir.y = 0;
        // 회전을 오일러각이 아닌 
        // rotation값으로 계산
        transform.rotation = Quaternion.LookRotation(dir);

    }

    void RotateStep()
    {
        float rSpeed = 10.0f;
        float step = rSpeed * Time.deltaTime;
        Vector3 curDir = transform.forward;
        curDir.y = 0;
        dir.y = 0;
        Vector3 newDir = Vector3.RotateTowards(curDir, dir, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

	void Update ()
    {
        // 마우스 클릭하였을경우 
        if( Input.GetMouseButtonDown(0) )
        {
            // 카메라에서 광선(모니터 안쪽의 반직선)을 생성
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // 3D공간으로 발사
            if ( Physics.Raycast(ray, out hit ) )
            {
                // 충돌지점 검사
                if (hit.collider.name.Contains("Terrain") )
                {
                    endPos = hit.point;
                    dir = endPos - transform.position;

                    // Transform.LookAt 함수
                    // 해당 위치를 바라보게 한다.(Vector3함수)                        

                    // Quaternion.LookRotation
                    // 해당 위치를 바라보게 한다.(쿼터니언사용)                        
                    Debug.Log("Terrain충돌");
                }
            }
        }

        // 이동해야할 상황이면
        // 클릭한 지점으로 이동해야 하는 상황이면
        if (transform.position != endPos)
        {
            transform.position =
                Vector3.MoveTowards(transform.position,
                                    endPos,
                                    Time.deltaTime * speed);

//            RotateDirectly();
        }

        RotateStep();



    }
}
