using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main-Menu-Example");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Map1Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
