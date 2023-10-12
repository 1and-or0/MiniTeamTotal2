using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SoundManager>();

                if (_instance == null)
                {
                    GameObject gameObj = new GameObject();
                    gameObj.name = "SoundManager";
                    gameObj.AddComponent<SoundManager>();
                }
            }
            return _instance;
        }
    }

    public AudioClip clockAudio;
    private AudioSource MainSound;
    private void Awake()
    {

        if (_instance != null && _instance != this) 
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);

        MainSound = GetComponent<AudioSource>();
    }

    public void PlayClock()
    {
        MainSound.clip = clockAudio;
        MainSound.Play();
    }

    public void StopClock()
    {
        MainSound.Stop();
    }

}
