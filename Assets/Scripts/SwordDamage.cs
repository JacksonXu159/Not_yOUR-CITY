using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    private GameObject gameObjectReceivingDamage;

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (gameObjectReceivingDamage == null) return;
        if (gameObjectReceivingDamage.tag == "Guiliani")
        {
            gameObjectReceivingDamage.GetComponent<BossController>().TakeDamage(3);
        }

        if (gameObjectReceivingDamage.tag == "bullet")
        {
            Destroy(gameObjectReceivingDamage);
        }

        if (gameObjectReceivingDamage.tag == "baldEnemy")
        {
            gameObjectReceivingDamage.GetComponent<EnemyFollowPlayer>().health -= 10;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        gameObjectReceivingDamage = collision.gameObject;
    }   
    void OnTriggerExit2D(Collider2D collision)
    {
        gameObjectReceivingDamage = null;
    }
}
