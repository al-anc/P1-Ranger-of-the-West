using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Player;
    public GameObject PauseMenuObj;
    private RangerOfTheWestActions Actions;
    private void OnEnable()
    {
        Actions.Enable();
    }
    private void OnDisable()
    {
        Actions.Disable();
    }
    public void ResumeGame()
    {
        PauseMenuObj.SetActive(false);
        Player.GetComponent<PlayerController>().Paused = false;
        Time.timeScale = 1;
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Retry!");
        Time.timeScale = 1;
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
