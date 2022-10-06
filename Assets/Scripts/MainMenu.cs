using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject SettingsMenu;
    
    public void PlayGame()
    {
        Debug.Log("Game Started!");
        SceneManager.LoadScene("Level");
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Settings()
    {
        SettingsMenu.SetActive(true);
    }
    public void SettingsInactive()
    {
        SettingsMenu.SetActive(false);
    }
}
