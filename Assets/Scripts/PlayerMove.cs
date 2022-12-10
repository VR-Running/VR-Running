using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    private Transform tr;

    public float moveSpeed = 10.0f; // �̵� �ӷ�
    public float turnSpeed = 80.0f; // ȸ�� �ӷ�


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);  // �̵� ���� ���

        // ������ ����Ʈ�� ���� �ӵ��� �޶����� ���� �ذ� : Time.deltaTime
        // �밢�� �̵� �� �ӵ��� �������Ƿ� normalized
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);

        // ���콺 �¿� �����ӿ� ���� ȸ��
        tr.Rotate(Vector3.up * turnSpeed * Time.deltaTime * r);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collider");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Jump"))
        {
            float jumpPower = collision.transform.GetComponent<SuperJump>().jumpPower;
            rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            Debug.Log("jump");
        }
    }
}
