using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public Transform startPoint;    // The starting point of the laser beam
    public float maxLength = 50f;   // The maximum length of the laser beam
    public LayerMask layerMask;     // The layer mask used for raycasting

    private LineRenderer lineRenderer;
    private Vector2 endPoint;       // The endpoint of the laser beam

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Cast a ray from the start point in the direction of the transform's up vector
        RaycastHit2D hit = Physics2D.Raycast(startPoint.position, transform.up, maxLength, layerMask);

        // If the ray hits something, set the endpoint to the hit point
        if (hit.collider != null)
        {
            endPoint = hit.point;
        }
        // Otherwise, set the endpoint to the maximum length
        else
        {
            endPoint = startPoint.position + transform.up * maxLength;
        }

        // Set the positions of the LineRenderer component
        lineRenderer.SetPosition(0, startPoint.position);
        lineRenderer.SetPosition(1, endPoint);

        // Rotate the laser beam around the start point
        transform.RotateAround(startPoint.position, Vector3.forward, 10f * Time.deltaTime);
    }
}
