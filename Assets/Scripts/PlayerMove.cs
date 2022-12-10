using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody Rigidbody;


    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collider");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Jump"))
        {
            float jumpPower = collision.transform.GetComponent<SuperJump>().jumpPower;
            Rigidbody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            Debug.Log("jump");
        }
    }
}
