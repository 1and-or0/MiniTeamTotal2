using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageMenu : MonoBehaviour
{
    public Button[] buttons;
    public int UnlockedLevel = 1;
    private void Awake()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

    }

    void Start()
    {
        UnlockedLevel = PlayerPrefs.GetInt("UnlockedLevel");
        for (int i = 0; i < UnlockedLevel; i++)
        {
            if (i > buttons.Length - 1)
                break;
            buttons[i].interactable = true;
        }
    }

    /// <summary>
    /// 스테이지 levelID를 여는 함수
    /// </summary>
    /// <param name="levelId"></param>
    public void OpenLevel(int levelId)
    {
        string levelName = "Stage" + levelId;
        SceneManager.LoadScene(levelName);
    }
}
