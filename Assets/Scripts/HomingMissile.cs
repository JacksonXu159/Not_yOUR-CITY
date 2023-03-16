using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{

    public Transform target;
    public float speed = 100000f;
    public float rotateSpeed = 200f;
    private Rigidbody2D rb;
    public GameObject explosionEffect;

    private float spawnTime;
    private float maxTime = 3f; // maximum time for the missile to follow the target

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        spawnTime = Time.time; // save the spawn time of the missile
    }

    void FixedUpdate()
    {
        Vector2 direction;

        // check if the missile has been spawned for more than maxTime seconds
        if (Time.time - spawnTime >= maxTime)
        {
            // if it has, stop following the target and head in the same direction as before
            direction = rb.velocity.normalized;
        }
        else
        {
            // if it hasn't, continue following the target
            direction = (Vector2)target.position - rb.position;
            direction.Normalize();
        }

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
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "baldEnemy")
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            collision.gameObject.GetComponent<EnemyFollowPlayer>().health -= 15;
            Destroy(gameObject);

        }
    }

}