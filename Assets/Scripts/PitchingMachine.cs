using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchingMachine : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;
    public float fourSeamForce; // 직구
    public float curveForce; // 커브
    public float pitchInterval; // 투구 사이 간격

    private void Start()
    {
        InvokeRepeating("ThrowRandomPitch", 2f, pitchInterval); // 2초후부터 인터벌마다 발사
    }

    private void ThrowRandomPitch()
    {
        int pitchType = Random.Range(0, 2);

        switch (pitchType)
        {
            case 0:
                ThrowFourSeam();
                break;
            case 1:
                ThrowCurveBall();
                break;
        }
    }

    // 직구
    private void ThrowFourSeam()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.AddForce(spawnPoint.forward * fourSeamForce, ForceMode.Impulse);
        Destroy(ball, 10f);
    }

    // 커브 (아래로 향하는 궤적)
    private void ThrowCurveBall()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.AddForce(spawnPoint.forward * curveForce, ForceMode.Impulse);

        // 아래로 떨어지도록 회전력 추가
        ballRigidbody.angularVelocity = new Vector3(0, 0, 5f);

        Destroy(ball, 10f);
    }
}
