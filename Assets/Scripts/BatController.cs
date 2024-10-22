using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public float minHitForce = 2f;  // �ּ� ��
    public float maxHitForce = 10f;  // �ִ� ��

    private Vector3 previousPosition;  // ��Ʈ�� ���� ������ ��ġ
    private float swingSpeed;  // ��Ʈ�� ���� �ӵ�

    private void Start()
    {
        previousPosition = transform.position;  // ���� �� ��Ʈ�� ��ġ �ʱ�ȭ
    }

    private void Update()
    {
        // ��Ʈ�� ���� �ӵ��� ��� (�̵��� �Ÿ� / �ð�)
        swingSpeed = (transform.position - previousPosition).magnitude / Time.deltaTime;
        previousPosition = transform.position;  // ���� ��ġ ����
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ���� �浹�ϸ�
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // ���� �ӵ��� ���� Ÿ�� �Ŀ��� ����
            float hitPower = Mathf.Clamp(swingSpeed * 10f, minHitForce, maxHitForce); // �ӵ��� ����� Ÿ�� �� ���

            // ��Ʈ�� ���� ġ�� ���� ���
            Vector3 hitDirection = collision.transform.position - transform.position;

            // ���� ���� ���� ���ư��� ��
            ballRigidbody.AddForce(hitDirection.normalized * hitPower, ForceMode.Impulse);
        }
    }
}
