//camera.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform playTransform;
    public Vector3 offset;


    void LateUpdate()
    {
        transform.position = playTransform.position + offset;
    }
}