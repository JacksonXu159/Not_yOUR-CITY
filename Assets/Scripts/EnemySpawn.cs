using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private List<Vector3> spawnPositionList;
    public GameObject player;
    public GameObject enemy;
    public int wave;
    public int waveOneAmount;
    public int waveTwoAmount;
    public int waveThreeAmount;
    public int interval;
    private float kills;
    private string currWave = "1";
    private string waveAmount = "10";
    private string currentKills = "0";
    
    public TMPro.TextMeshProUGUI waveUI;



    // Start is called before the first frame update
    void Start()
    {
        spawnPositionList = new List<Vector3>();
        foreach (Transform spawnPoint in transform.Find("spawnPositions"))
        {
            spawnPositionList.Add(spawnPoint.position);
        }

        StartCoroutine(spawnEnemy(interval, enemy, waveOneAmount));
        wave = -1;

    }

    // Update is called once per frame
    void Update()
    {
        kills = player.GetComponent<PlayerController>().enemyKills;


        if (wave == 2){
            StartCoroutine(spawnEnemy(interval, enemy, waveTwoAmount));
            currWave = wave.ToString();
            waveAmount = waveTwoAmount.ToString();
            wave = -2;
        }

        if (wave == 3){
            StartCoroutine(spawnEnemy(interval, enemy, waveThreeAmount));
            currWave = wave.ToString();
            waveAmount = waveThreeAmount.ToString();
            wave = -3;
        }

        if (wave == -1){
            if (player.GetComponent<PlayerController>().enemyKills == waveOneAmount){
                Debug.Log("wave2");
                wave = 2;
            }
        }

        if (wave == -2){
            kills -= 10;
            if (player.GetComponent<PlayerController>().enemyKills == waveTwoAmount + 10){
                Debug.Log("wave3");
                wave = 3;
            }
        }

        if (wave == -3){
            kills -= 25;
        }

        currentKills = kills.ToString();
        waveUI.text = "Wave: " + currWave  + ": " + currentKills + "/" + waveAmount;

        
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy, float iterationCount)
    {
        for(int i = 0; i < iterationCount; i++)
        {
            yield return new WaitForSeconds(interval);
            Vector3 spawnPosition = spawnPositionList[Random.Range(0, spawnPositionList.Count)];
            GameObject enemySpawn = Instantiate(enemy, spawnPosition, Quaternion.identity);
        }

        
        //StartCoroutine(spawnEnemy(interval, enemy));
    }
}
