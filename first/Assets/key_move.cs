//key_move.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveForward : MonoBehaviour
{
    public float speed = 10f; // 오브젝트 속도
    public float turnSpeed = 100f; // 오브젝트 회전 속도
    private Rigidbody rb; // Rigidbody 컴포넌트

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 1f; // 적절한 질량 설정
        rb.drag = 0f; // 공기 저항
        rb.angularDrag = 0.05f; // 회전에 대한 저항
        rb.interpolation = RigidbodyInterpolation.Interpolate; // 부드러운 움직임
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous; // 연속 충돌 감지
    }

    void FixedUpdate()
    {
        float moveForward = 0f;
        float moveTurn = 0f;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveForward = speed;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveForward = -speed;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveTurn = -turnSpeed;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveTurn = turnSpeed;
        }

        // 이동 처리
        Vector3 movement = transform.forward * moveForward * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        // 회전 처리
        if (moveTurn != 0)
        {
            Quaternion turnRotation = Quaternion.Euler(0f, moveTurn * Time.fixedDeltaTime, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }

        
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // 벽에 닿아 있는 동안 속도와 각속도를 0으로 유지
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
