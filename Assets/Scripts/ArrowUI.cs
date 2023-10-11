using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowUI : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 dragStart;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // 화살표의 시작점과 종료점
        lineRenderer.enabled = false; // 초기에는 화살표를 비활성화
    }

    private void Update()
    {
        if (BallManager.Instance.isTurn)
        {
            // 마우스 버튼을 누르면 드래그 시작
            if (Input.GetMouseButtonDown(0))
            {
                dragStart = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4f)); // z값을 조절하여 화살표의 깊이를 설정
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, dragStart);
            }

            // 드래그 중일 때 화살표 업데이트
            if (Input.GetMouseButton(0))
            {
                Vector3 dragEnd = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4f));
                lineRenderer.SetPosition(1, dragStart - dragEnd + dragStart);
            }

            // 마우스 버튼을 놓으면 드래그 종료
            if (Input.GetMouseButtonUp(0))
            {
                lineRenderer.enabled = false;
            }
        }
        
    }
}
