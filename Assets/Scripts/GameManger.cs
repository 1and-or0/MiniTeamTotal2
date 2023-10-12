using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public GameObject gameOverSet;
    public GameObject gameClearSet;
    public CountDownController CountDown;
    private static GameManger instance;
    public int PinScore = 1;
    public int BallScore = 1;

    void Update()
    {
        PinScore = GameObject.FindGameObjectsWithTag("Pin").Length;
        if (PinScore == 0 && CountDown.IsGameStart == true)
        {
            GameClear();
            CountDown.IsGameStart = false;
        }

        BallScore = GameObject.FindGameObjectsWithTag("Ball").Length;
        if(BallScore==0 && CountDown.IsGameStart == true)
        {
            GameOver();
            CountDown.IsGameStart = false;
        }

    }

    public void GameOver()
    {
        gameOverSet.SetActive(true);
        CountDown.IsGameStart = false;

    }

    public void GameClear()
    {
        gameClearSet.SetActive(true);
        CountDown.IsGameStart = false;
        int temp = PlayerPrefs.GetInt("UnlockedLevel");
        PlayerPrefs.SetInt("UnlockedLevel", ++temp);
        Debug.Log(PlayerPrefs.GetInt("UnlockedLevel"));
    }
}
