using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private Ball _ballCs;
    public bool isTurn = false;
    public float velocityThreshold = 0.1f;
    public List<GameObject> ballObjs = new List<GameObject>();
    
    // 싱글턴 인스턴스
    private static BallManager _instance;

    // 외부에서 접근 가능한 인스턴스 프로퍼티
    public static BallManager Instance
    {
        get
        {
            // _instance가 null이면 씬에서 BallManager 타입을 찾아 할당
            if (_instance == null)
            {
                _instance = FindObjectOfType<BallManager>();

                // 여전히 null이면 새 게임 오브젝트와 BallManager 컴포넌트를 생성
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "BallManager";
                    _instance = obj.AddComponent<BallManager>();
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        // 다른 BallManager 인스턴스가 이미 있으면 현재 인스턴스를 파괴
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않도록 설정
    }

    void Start()
    {
        isTurn = true;

        _ballCs = FindAnyObjectByType<Ball>();
         
        Debug.Log("공의 개수: " + GameObject.FindGameObjectsWithTag("Ball").Length);
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Ball").Length; ++i)
        {
            ballObjs.Add(GameObject.FindGameObjectsWithTag("Ball")[i]);
        }
    }

    void Update()
    {
        isTurn = AreBallsStopped();
    }

    public bool AreBallsStopped()
    {
        foreach (var ball in ballObjs)
        {
            if (ball != null)
            {
                Rigidbody ballRb = ball.GetComponent<Rigidbody>();

                if (ballRb.velocity.magnitude > velocityThreshold ||
                ballRb.angularVelocity.magnitude > velocityThreshold)
                {
                    return false; // 하나라도 움직이는 공이 있다면 false 반환
                }
            }
        }
        return true; // 모든 공이 멈췄다면 true 반환
    }
}
