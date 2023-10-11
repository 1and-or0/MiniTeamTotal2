using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOnDeadzone : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.collider.tag == "Deadzone")
        {
            Destroy(gameObject);
        }
    }
}
