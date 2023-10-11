using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHitCount : MonoBehaviour
{
    public int count = 0;
    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rigidbody.velocity.magnitude < 0.05f)
            count = 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.collider.tag == "Pin")
        {
            count++;
            switch (count)
            {
                case 2:
                    Debug.Log("이타!");
                    break;
                case 3:
                    Debug.Log("삼타!");
                    break;
                case 4:
                    Debug.Log("사타!");
                    break;
                default: 
                    break;
            }
        }
    }
}
