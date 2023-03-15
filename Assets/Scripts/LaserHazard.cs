using UnityEngine;

public class LaserHazard : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private LineRenderer lineRenderer;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Update()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        // Create a LayerMask to ignore objects with the "IgnoreRaycast" layer
        LayerMask layerMask = LayerMask.GetMask("Default");
        layerMask |= LayerMask.GetMask("Ground");
        layerMask |= LayerMask.GetMask("Player");
        layerMask |= LayerMask.GetMask("OtherLayerName");
        layerMask = ~LayerMask.GetMask("Ignore Raycast");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, Mathf.Infinity, layerMask);

        if(hit.collider.CompareTag("Player"))
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
            hit.collider.GetComponent<PlayerController>().TakeDamage(0.01f);
        }

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, hit.point);
    }

}
