using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public GameObject Player;
    public GameObject PauseMenu;

    public void PlayGame()
    {
        Debug.Log("Game Started!");
        SceneManager.LoadScene("SampleScene");
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

    public void ResetGame() {
        SceneManager.LoadScene("Main Menu");
    }
        public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Retry!");
        Time.timeScale = 1;
    }
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Player.GetComponent<PlayerController>().Paused = false;
        Time.timeScale = 1;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

}
