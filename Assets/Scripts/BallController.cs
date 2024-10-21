using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Transform batPosition;  // 배트의 위치 (비거리 계산용)
    public TextMeshProUGUI distanceText;  // 비거리 표시
    private Vector3 startPosition;  // 공의 초기 위치 (초기화 용)
    private Rigidbody rigid;

    private void Start()
    {
        startPosition = transform.position;  // 공의 초기 위치 저장
        rigid = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 배트와 충돌 시
        if (collision.gameObject.CompareTag("Bat"))
        {
            // 타격 후 비거리 측정 시작
            Invoke("CalculateDistance", 1f);  // 1초 후 비거리 계산 (공이 충분히 날아간 후 계산)
        }
    }

    private void CalculateDistance()
    {
        // 배트에서 공이 날아간 거리를 계산
        float distance = Vector3.Distance(batPosition.position, transform.position);
        distanceText.text = "비거리: " + distance.ToString("F2") + " m";  // UI에 비거리 표시
    }

    public void ResetBall()
    {
        // 공을 원래 위치로 리셋
        transform.position = startPosition;
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }
}
