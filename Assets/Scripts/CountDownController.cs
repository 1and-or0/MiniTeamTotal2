using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountDownController : MonoBehaviour
{
    public bool IsGameStart = false;
    public int countDownTimer;
    public Text countDownDisplay;
    private void Start()
    {
        StartCoroutine(CountDown());
    }
    IEnumerator CountDown()
    {
        while (countDownTimer > 0)
        {
            countDownDisplay.text = countDownTimer.ToString();
            yield return new WaitForSeconds(1f);
            countDownTimer--;
        }
        countDownDisplay.text = "Go!!";
        // SceneManager.LoadScene("Stage1");

        yield return new WaitForSeconds(1f);
        IsGameStart = true;
        countDownDisplay.gameObject.SetActive(false);
    }
}
