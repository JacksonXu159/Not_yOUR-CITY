using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Guiliani")
        {
            collision.gameObject.GetComponent<BossController>().health -= 3;
        }

        if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "baldEnemy")
        {
            collision.gameObject.GetComponent<EnemyFollowPlayer>().health -= 10;
        }
    }
}
