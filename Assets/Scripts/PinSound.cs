using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSound : MonoBehaviour
{
    public AudioClip pinTick;
    public AudioClip pinOut;
    public AudioSource pinSource;

    void Awake()
    {
        pinSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Deadzone")
        {
            pinSource.PlayOneShot(pinOut);
        }
        else if (collision.collider.tag == "Ball")
        {
            pinSource.PlayOneShot(pinTick);
        }
    }
}
