using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int Score = 0;
    public GameObject textObj;
    private Text text;

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
        textObj = GameObject.FindGameObjectWithTag("Score");
        text= textObj.GetComponent<Text>();
        
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
        textObj = GameObject.FindGameObjectWithTag("Score");
        text = textObj.GetComponent<Text>();
        Score = 0;

    }
    private void Update()
    {
        text.text = "Score: " + Score;
    }
}
