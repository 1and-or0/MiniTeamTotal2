using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timecontroller : MonoBehaviour
{
    public CountDownController CountDown;
    public GameManger manager;
    public float GameTime = 30;
    public Text GameTimeText;
    public bool isPlay = false;
    private void Update()
    {
        if (CountDown.IsGameStart == true)
        {
            GameTime -= Time.deltaTime;
            GameTimeText.text = "Time: " + (int)GameTime;
            if (!isPlay )
            {
                SoundManager.Instance.PlayClock();
                isPlay = true;
            }
        }

        if ((int)GameTime == 0)
        {
            manager.GameOver();
            CountDown.IsGameStart = false;
        }
    }

    private void Awake()
    {
        SceneManager.sceneLoaded += sceneLoaded;
    }

    private void sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        isPlay = false;
    }
}
