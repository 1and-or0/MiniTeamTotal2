using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public GameObject ScoreTMP;
    public int Score = 0;

    private static ScoreManager _instance;
    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreManager>();

                if ( _instance == null ) 
                {
                    GameObject gameObj = new GameObject();
                    gameObj.name = "ScoreManager";
                    gameObj.AddComponent<ScoreManager>();
                }
            }
            return _instance;
        }
    }

    void Awake()
    {
        if ( _instance != null && _instance != this ) 
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += sceneLoaded;
    }

    void sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Score = 0;
    }
}
