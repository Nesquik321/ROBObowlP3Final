using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 4f, -6f);
    public float followSpeed = 8f;
    public float rotationSmoothTime = 0.1f;

    private Vector3 currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, 1f /  followSpeed);

        Vector3 lookAtPoint = target.position + Vector3.forward * 5f;
        transform.LookAt(lookAtPoint);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
