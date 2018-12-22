using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MovableEntity {

    public KeyboardController _controller;
    // Use this for initialization
    float missileDuration = 1;
    public float maxMissileDuration = 0.5f;

    void Start () {
        Debug.Log("Avatar Start");
	}
	
	// Update is called once per frame
	void Update () {
        Move(_controller.GetDir());
        Shoot();
	}

    void Shoot()
    {
        if (missileDuration < maxMissileDuration)
        {
            missileDuration += Time.deltaTime;
            return;
        }

        if (!_controller.IsShoot()) return;

        missileDuration = 0; // 코루틴을 안쓰고 이렇게 쓰시는구나.

        GameObject prefab = Resources.Load("Prefabs/Missiles/AvatarMissile") as GameObject;
        // as GameObject : 캐스팅 (GameObject)
        // Resources 를 사용하는 이유 : 패치가 가능하다. 즉, 수정이 생기면 폴더를 바꿔치기만 하면된다. 근데 하이럴키의 프리팹으로 하면 수정이 생겼을 때 재빌드를 해야함. 
        // 그냥 프리팹에 넣어서 쓰면 파일 io가 적다. 하지만 resources를 쓰면 한번 땡길때 파일 io가 좀 생긴다.
        // 지금은 미사일 쓸때마다 폴더에서 땡겨오니까 낭비가 심함. 한번 땡겨오면 그 후부터는 계속 재사용할 수 있도록 나중에 코드 수정해줄거임

        prefab.GetComponent<Missile>()._speed = 5;

        // 지금 하면 내 캐릭터와 동일한 위치에 생기는데 이렇게 하면 충돌이 약간 일어날수있으니까 별로 좋은 코드는 아니다.
        // 이제 이걸 변경하자. 그래서 new Vector3(0,0.5f,0)을 더해줬는데... 이거 말고 다른방법 있대. 뭘까.
        //prefab.GetComponent<Missile>().Init(new Vector2(0, 1f), transform.position + new Vector3(0, 0.5f,0));

        Vector3 pos = transform.GetChild(0).transform.position;
        prefab.GetComponent<Missile>().Init(new Vector2(0, 1f), pos);


        GameObject missile = Instantiate(prefab);
        //Instantiate를 해야 객체가 씬에 붙으니까 그때 missile의 Start()가 실행된다.
        // 즉, Init() -> Start() 순서.
    }
}
