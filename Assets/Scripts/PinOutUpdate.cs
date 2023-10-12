using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinOutUpdate : MonoBehaviour
{

    void OnDestroy()
    {
        // PinManager.Instance.OutPinNum += 1;

        ScoreManager.Instance.Score += 100;
    }
}
