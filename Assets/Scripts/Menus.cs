using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
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

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

}
