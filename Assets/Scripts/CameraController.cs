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

        if (transform.position.y > 7.76f)
        {
            transform.position = new Vector3(transform.position.x, 7.75f, transform.position.z);
        }

        if (transform.position.y < -11.97)
        {
            transform.position = new Vector3(transform.position.x, -11.96f, transform.position.z);
        }

        if (transform.position.x > 10.79f)
        {
            transform.position = new Vector3(10.78f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -17.90f)
        {
            transform.position = new Vector3(-17.89f, transform.position.y, transform.position.z);
        }

    }
}
