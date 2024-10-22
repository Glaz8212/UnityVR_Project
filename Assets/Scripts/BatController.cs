using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public float minHitForce = 2f;  // 최소 힘
    public float maxHitForce = 10f;  // 최대 힘

    private Vector3 previousPosition;  // 배트의 이전 프레임 위치
    private float swingSpeed;  // 배트의 스윙 속도

    private void Start()
    {
        previousPosition = transform.position;  // 시작 시 배트의 위치 초기화
    }

    private void Update()
    {
        // 배트의 현재 속도를 계산 (이동한 거리 / 시간)
        swingSpeed = (transform.position - previousPosition).magnitude / Time.deltaTime;
        previousPosition = transform.position;  // 이전 위치 갱신
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 공과 충돌하면
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // 스윙 속도에 따라 타격 파워를 결정
            float hitPower = Mathf.Clamp(swingSpeed * 10f, minHitForce, maxHitForce); // 속도에 비례한 타격 힘 계산

            // 배트가 공을 치는 방향 계산
            Vector3 hitDirection = collision.transform.position - transform.position;

            // 공에 힘을 가해 날아가게 함
            ballRigidbody.AddForce(hitDirection.normalized * hitPower, ForceMode.Impulse);
        }
    }
}
