using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float life = 1;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "baldEnemy")
        {
            collision.gameObject.GetComponent<EnemyFollowPlayer>().health -= 10;
            Destroy(gameObject);
        }


        if (collision.gameObject.tag == "Guiliani")
        {
            collision.gameObject.GetComponent<BossController>().TakeDamage(2);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "barrier")
        {
            Destroy(gameObject);
        }
    }
}