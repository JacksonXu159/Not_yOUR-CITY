using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerBullet : MonoBehaviour
{
    public float life = 3;
 
    void Awake()
    {
        Destroy(gameObject, life);
    }
 
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "baldEnemy")
        {
            collision.gameObject.GetComponent<EnemyFollowPlayer>().health -= 10;
            collision.gameObject.GetComponent<EnemySpawner>().health -=10;
            Destroy(gameObject);
        }
    }
}