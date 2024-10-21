using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Transform batPosition;  // ��Ʈ�� ��ġ (��Ÿ� ����)
    public TextMeshProUGUI distanceText;  // ��Ÿ� ǥ��
    private Vector3 startPosition;  // ���� �ʱ� ��ġ (�ʱ�ȭ ��)
    private Rigidbody rigid;

    private void Start()
    {
        startPosition = transform.position;  // ���� �ʱ� ��ġ ����
        rigid = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ��Ʈ�� �浹 ��
        if (collision.gameObject.CompareTag("Bat"))
        {
            // Ÿ�� �� ��Ÿ� ���� ����
            Invoke("CalculateDistance", 1f);  // 1�� �� ��Ÿ� ��� (���� ����� ���ư� �� ���)
        }
    }

    private void CalculateDistance()
    {
        // ��Ʈ���� ���� ���ư� �Ÿ��� ���
        float distance = Vector3.Distance(batPosition.position, transform.position);
        distanceText.text = "��Ÿ�: " + distance.ToString("F2") + " m";  // UI�� ��Ÿ� ǥ��
    }

    public void ResetBall()
    {
        // ���� ���� ��ġ�� ����
        transform.position = startPosition;
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }
}
