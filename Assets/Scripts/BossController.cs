using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    [SerializeField]
    private GameObject misslePrefab;
    

    [SerializeField]
    private float missleInterval = 1f;
    public float health = 100f; // maximum health of the object// current health of the object
    
    // Start is called before the first frame update
    void Start()
    {
        CheckHealth(); // check the health and start the coroutine if necessary
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, transform.position + new Vector3(-2,1), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }

    void Update(){
        if(health <=0){
            Debug.Log("dead");
            Destroy(gameObject);
        }
    }

    private void CheckHealth()
    {
        if (health > 65) // check if the current health is below 75
        {
            StartCoroutine(spawnEnemy(missleInterval, misslePrefab)); // start the coroutine
        }
    }   


}
