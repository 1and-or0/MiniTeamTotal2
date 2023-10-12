using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager Instance
    {
        get 
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LevelManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "LevelManager";
                    _instance = obj.AddComponent<LevelManager>();
                }
            }

            return _instance; 
        }

    }

    public GameObject level;

    void Awake()
    {
        // 다른 BallManager 인스턴스가 이미 있으면 현재 인스턴스를 파괴
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않도록 설정

        PlayerPrefs.SetInt("UnlockedLevel", 1);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        //level = transform.GetChild(0).gameObject;
        //Debug.Log(level.name);
    }

    /// <summary>
    /// Scene이 처음 로드될 때 초기화하는 함수
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            // Title 화면
            case 0:
                if (level != null)
                {
                    level.SetActive(false);
                }
                break;
            default:
                break;
        }
    }
}
