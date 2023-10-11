using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncinessBySpeed : MonoBehaviour
{
    private Collider ballCd;
    private Rigidbody ballRb;
    public float maxBounciness = 1f;      // 최대 bounciness 값
    public float speedFactor = 5f;        // 속도를 조절하는 인자 (더 큰 값은 더 빠른 변화를 초래함)
    private PhysicMaterial ballPMaterial;

    void Start()
    {
        ballCd = GetComponent<Collider>();
        ballCd.material.bounciness = 1;
        ballRb = GetComponent<Rigidbody>();
        ballPMaterial = ballCd.GetComponent<PhysicMaterial>();
    }


    void Update()
    {
        if (ballPMaterial)
        {
            float speed = ballRb.velocity.magnitude;
            ballPMaterial.bounciness = maxBounciness / (1 + speed/speedFactor);
        }
    }
}
