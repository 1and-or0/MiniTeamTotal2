using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinManager : MonoBehaviour
{
    private static PinManager _instance;
    public static PinManager Instance
    {
        get 
        { 
            if (_instance == null)
            {
                _instance = FindObjectOfType<PinManager>();

                if (_instance == null )
                {
                    GameObject gameObj = new GameObject();
                    gameObj.name = "PinManager";
                    gameObj.AddComponent<PinManager>();
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

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PinNum = 0;
        OutPinNum = 0;
        tempOut = 0;
    }

    public int PinNum = 0;
    public int OutPinNum = 0;
    public int tempOut = 0;

    void Update()
    {
        PinNum = GameObject.FindGameObjectsWithTag("Pin").Length;

        if (!BallManager.Instance.isTurn) 
        {
            if (OutPinNum != 0) 
            {
                tempOut = OutPinNum;            
            }
        }
    }

    
}
