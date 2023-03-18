using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    void Update()
    {

        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        if (transform.position.y > 8.06f)
        {
            transform.position = new Vector3(transform.position.x, 8.06f, transform.position.z);
        }

        if (transform.position.y < -12.02)
        {
            transform.position = new Vector3(transform.position.x, -12.02f, transform.position.z);
        }

        if (transform.position.x > 14.58f)
        {
            transform.position = new Vector3(14.58f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -21.67f)
        {
            transform.position = new Vector3(-21.67f, transform.position.y, transform.position.z);
        }

    }
}
