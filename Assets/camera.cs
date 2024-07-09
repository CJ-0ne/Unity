//camera.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject Target;

    public float offsetX = -55f;            // 카메라의 x좌표
    public float offsetY = 6.8f;           // 카메라의 y좌표
    public float offsetZ = -25f;          // 카메라의 z좌표

    public float CameraSpeed = 10.0f;
    Vector3 TargetPos;

    void LateUpdate()
    {
        TargetPos = new Vector3(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ
            );
        //카메라 움직임 smooth
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
    }
}