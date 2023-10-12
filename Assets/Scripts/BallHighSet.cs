using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHighSet : MonoBehaviour
{
    Vector3 startPos = new Vector3();

    void Awake()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // 볼이 점점 위로 올라가는 것을 방지
        if (transform.position.y > startPos.y)
        {
            transform.position = startPos;
        }
    }
}
