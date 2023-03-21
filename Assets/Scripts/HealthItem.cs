using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    private float plrHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("yes");
            plrHealth = collision.gameObject.GetComponent<PlayerController>().currentHealth;

            if ((plrHealth < 100) && (plrHealth > 90)){
                Debug.Log("over 90");
                collision.gameObject.GetComponent<PlayerController>().healPlr(plrHealth % 10);
                Destroy(gameObject);
            }else if (plrHealth <= 90){
                Debug.Log("under 90");
                collision.gameObject.GetComponent<PlayerController>().healPlr(10);
                Destroy(gameObject);
            }
        }
    }

}
