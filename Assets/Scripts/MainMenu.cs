using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject SettingsMenu;
    private RangerOfTheWestActions Actions;
    private bool settings;
    private void OnEnable()
    {
        Actions.Enable();
    }
    private void OnDisable()
    {
        Actions.Disable();
    }
    
    public void PlayGame()
    {
        Debug.Log("Game Started!");
        SceneManager.LoadScene("Level");
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        settings = false;
    }
    void Update()
    {
                    bool Resume = Actions.UI.Back.ReadValue<float>() > 0.1f;
            if (Resume && settings == true)
            {
            SettingsMenu.SetActive(false);
            }
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
        settings = true;
    }
    public void SettingsInactive()
    {
        SettingsMenu.SetActive(false);
    }
}
