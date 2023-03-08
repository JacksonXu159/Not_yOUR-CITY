using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissle : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    public float speed = 5f;
    public float rotateSpeed = 200f;
    private Rigidbody2D rb;
    public GameObject explosionEffect;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(15);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "bullet")
        {
            Debug.Log("yes");
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}
