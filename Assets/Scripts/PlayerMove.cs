using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    private Transform tr;

    public float moveSpeed = 10.0f; // 이동 속력
    public float turnSpeed = 80.0f; // 회전 속력


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

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);  // 이동 벡터 계산

        // 프레임 레이트에 따라 속도가 달라지는 문제 해결 : Time.deltaTime
        // 대각선 이동 시 속도가 빨라지므로 normalized
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);

        // 마우스 좌우 움직임에 따라 회전
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
