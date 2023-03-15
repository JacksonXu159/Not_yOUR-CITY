using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    [SerializeField]
    private GameObject misslePrefab;
    

    [SerializeField]
    private float missleInterval = 1f;

    [SerializeField]
    private GameObject eyePrefab;

    public float health = 100f; // maximum health of the object// current health of the object
    
    // Start is called before the first frame update
    void Start()
    {
        CheckHealth(); // check the health and start the coroutine if necessary
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, transform.position + new Vector3(-2f,0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }

    private IEnumerator spawnEyes(GameObject enemy)
    {
        GameObject leftEye = Instantiate(enemy, transform.position + new Vector3(0.183f, 0.35f), Quaternion.identity);
        GameObject rightEye = Instantiate(enemy, transform.position + new Vector3(-1.117f,0.35f), Quaternion.identity);
        yield return null;
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
            //StartCoroutine(spawnEnemy(missleInterval, misslePrefab)); // start the coroutine
            StartCoroutine(spawnEyes(eyePrefab));
        }
    }   


}
