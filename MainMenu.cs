using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string level1;
    public string mainScreen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(level1);
    }

    public void OpenOptions()
    {

    }

    public void CloseOptions()
    {

    }

    public void Controls()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void GoBack()
    {
        SceneManager.LoadScene(mainScreen);
    }
}
