using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {
    private static GameStateManager _instance;
    public static GameStateManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = GameObject.FindObjectOfType(typeof(GameStateManager)) as GameStateManager;
                if (!_instance)
                {
                    GameObject container = new GameObject();
                    container.name = "GameStateMgr";
                    _instance = container.AddComponent(typeof(GameStateManager)) as GameStateManager;

                }
            }
            return _instance;
        }
    }

    public bool isPlaying = false;

    public GameObject UI_GameStart;
    public GameObject UI_GameOver;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameStart()
    {
        isPlaying = true; // 이 값에 따라 아바타 컨트롤 유무 조절, 적 생성 조절
        Debug.Log("Game Start");
        if(UI_GameStart)
        {
            UI_GameStart.SetActive(false);
        }

        // GameStart 판넬 제거
    }

    public void GameOver()
    {
        isPlaying = false; // 이 값에 따라 아바타 컨트롤 유무 조절, 적 생성 조절
        Debug.Log("Game Over");
        UI_GameOver.SetActive(true);
       
    }

    public void GoToGameStart()
    {
        UI_GameOver.SetActive(false);
        UI_GameStart.SetActive(true);
        isPlaying = false;
    }
}
