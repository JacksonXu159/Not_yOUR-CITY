using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    public float health = 100f; // maximum health of the object// current health of the object

    [SerializeField]
    private GameObject MissilePrefab;

    [SerializeField]
    private float MissileInterval = 1f;

    [SerializeField]
    private GameObject eyePrefab;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float enemyInterval = 1f;

    //[SerializeField] private ColliderTrigger colliderTrigger;

    private List<Vector3> spawnPositionList;

    int phase = 0;



    void Awake()
    {
        spawnPositionList = new List<Vector3>();
        foreach (Transform spawnPoint in transform.Find("spawnPositions"))
        {
            spawnPositionList.Add(spawnPoint.position);
        }

    }

    void Start()
    {
        //CheckHealth(); // check the health and start the coroutine if necessary
    }


    private IEnumerator spawnMissile(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, transform.position + new Vector3(-2f, 0), Quaternion.identity);
        StartCoroutine(spawnMissile(interval, enemy));
    }

    private IEnumerator spawnEyes(GameObject enemy)
    {
        GameObject leftEye = Instantiate(enemy, transform.position + new Vector3(0.183f, 0.35f), Quaternion.identity);
        GameObject rightEye = Instantiate(enemy, transform.position + new Vector3(-1.117f, 0.35f), Quaternion.identity);
        yield return null;
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        Vector3 spawnPosition = spawnPositionList[Random.Range(0, spawnPositionList.Count)];
        GameObject enemySpawn = Instantiate(enemy, spawnPosition, Quaternion.identity);
        
        StartCoroutine(spawnEnemy(interval, enemy));
    }

    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("dead");
            Destroy(gameObject);
        }

        if (phase == 0 && health <= 100f)
        {
            StartCoroutine(spawnEnemy(enemyInterval, enemyPrefab));

            phase = 1;
        }
        else if (phase == 1 && health <= 70f)
        {
            StartCoroutine(spawnMissile(MissileInterval, MissilePrefab));
            phase = 2;
        }
        else if (phase == 2 && health <= 30f)
        {
            StartCoroutine(spawnEyes(eyePrefab));
            phase = 3;
        }

    }


}