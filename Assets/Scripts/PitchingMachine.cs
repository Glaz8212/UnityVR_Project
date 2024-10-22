using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchingMachine : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;
    public float fourSeamForce; // ����
    public float curveForce; // Ŀ��
    public float pitchInterval; // ���� ���� ����

    private void Start()
    {
        InvokeRepeating("ThrowRandomPitch", 2f, pitchInterval); // 2���ĺ��� ���͹����� �߻�
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

    // ����
    private void ThrowFourSeam()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.AddForce(spawnPoint.forward * fourSeamForce, ForceMode.Impulse);
        Destroy(ball, 10f);
    }

    // Ŀ�� (�Ʒ��� ���ϴ� ����)
    private void ThrowCurveBall()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.AddForce(spawnPoint.forward * curveForce, ForceMode.Impulse);

        // �Ʒ��� ���������� ȸ���� �߰�
        ballRigidbody.angularVelocity = new Vector3(0, 0, 5f);

        Destroy(ball, 10f);
    }
}
