using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    public float lineOfSight;
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    private Transform player;
    public SpriteRenderer spriteRenderer;
    public float bulletSpeed = 10;
    Animator m_Animator;
    public float health = 20;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        m_Animator = gameObject.GetComponent<Animator>();
        m_Animator.SetBool("walking", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSight && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            m_Animator.SetBool("walking", true);
        }
        else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            // Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Vector2 moveDir = (player.transform.position - bulletSpawnPoint.position).normalized * bulletSpeed;
            //         bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(moveDir.x, moveDir.y); //bulletSpawnPoint.right * bulletSpeed;

            nextFireTime = Time.time + fireRate;
            m_Animator.SetBool("walking", false);
        }
        else if (distanceFromPlayer > lineOfSight)
        {
            m_Animator.SetBool("walking", false);

        }
        Flip();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.DrawWireSphere(transform.position, shootingRange);

    }

    void Flip()
    {
        if (player.position.x - transform.position.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (player.position.x - transform.position.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}