using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public string level;
    private GameObject player;
    private GameObject globalAudio;
    private GameObject goMenu;

    public void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        globalAudio = GameObject.FindGameObjectWithTag("GlobalAudio");
        goMenu = gameObject.transform.Find("GameOverMenu").gameObject;
        Time.timeScale = 1f;

    }
    public void Update(){
        if (player.GetComponent<PlayerController>().currentHealth <= 0){
            Time.timeScale = 0f;
            player.SetActive(false);
            globalAudio.SetActive(false);
            goMenu.SetActive(true);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
