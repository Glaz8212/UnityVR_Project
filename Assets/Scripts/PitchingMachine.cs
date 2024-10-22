using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchingMachine : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;
    public float pitchingForce;
    public float pitchInterval; // ���� ���� ����

    private void Start()
    {
        InvokeRepeating("PitchBall", 2f, pitchInterval); // 2���ĺ��� ���͹����� �߻�
    }

    private void PitchBall()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);

        Rigidbody rigid = ball.GetComponent<Rigidbody>();
        rigid.AddForce(spawnPoint.forward * pitchingForce, ForceMode.Impulse);

        Destroy(ball, 10f); // �� 10�� �� ����
    }
}
