using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        SoundManager.Instance.StopClock();
    }
    public void Home()
    {
        SceneManager.LoadScene("Title");
        Time.timeScale = 1;
        SoundManager.Instance.StopClock();
    }
    public void Resum()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        SoundManager.Instance.PlayClock();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        SoundManager.Instance.StopClock();
    }
}
