using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private Transform cameraTarget;
    [SerializeField] private float sSpeed = 10.0f;
    [SerializeField] private Vector3 dist;
    [SerializeField] private Transform lookAtTarget;

    private void FixedUpdate()
    {
        Vector3 dPos = cameraTarget.position + dist;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(lookAtTarget.position);
    }
}
