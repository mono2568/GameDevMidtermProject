using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Transform target;
    public float smoothTime = 0.3f;

    Vector3 velocity = Vector3.zero;


    public float maxTime = 2f;
    public float leftEnd = 2;
    public float rightEnd = 80;
    private bool stopCamera = false;
    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }
    public void FixedUpdate()
    {
        if (stopCamera) return;
        Vector3 targetPosition;
        targetPosition = target.TransformPoint(new Vector3(0, 2, -10f));
        if (target.transform.position.x < leftEnd)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(leftEnd, targetPosition.y, targetPosition.z), ref velocity, smoothTime);
        } else if (target.transform.position.x > rightEnd) {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(rightEnd, targetPosition.y, targetPosition.z), ref velocity, smoothTime);
        } else
        {
            //smoothly move the camera towards the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }

        
    }

    public void stopCameraMovement()
    {
        stopCamera = true;
    }
}
