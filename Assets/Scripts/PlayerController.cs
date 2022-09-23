using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float score;
    public float bonusScore;
    public float enemies;

    public Text scoreValue;
    public Text bonusText;
    public Text enemiesText;
    public Text gameOverText;
    public GameObject Pausemenu;
    public bool Paused;
    public bool attack;
    public LayerMask layer;
    public GameObject Enemy;

    public bool gameOver;

    void Awake()
    {
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        enemies = 40;
        bonusScore = 5000;
        InvokeRepeating("setBonusScore", 1, 1);

        scoreValue.text = ("Score: " + score.ToString());
        bonusText.text = ("Bonus: " + bonusScore.ToString());
        enemiesText.text = ("Enemies: " + enemies.ToString());
        gameOverText.text = ("");
        
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies == 0)
        {
            gameOver = true;
            enemiesText.text = ("Enemies: " + enemies.ToString());
            gameOverText.text = ($"Game Over! Final Score: {score} Press Esc to exit game.");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log ("Game Closed");
            Application.Quit();
        }
        if (Input.GetButtonDown("Pause") && Paused == false)
        {
            Pausemenu.SetActive(true);
            Paused = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        else if (Input.GetButtonDown("Pause")&& Paused == true)
        {
            Pausemenu.SetActive(false);
            Paused = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
                this.transform.position = Input.mousePosition;


        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        //var EnemyAI : enemy = hit.collider.GetComponent(EnemyAI);
        //layer = LayerMask.NameToLayer("Enemy");
        if (Input.GetButtonDown("Fire1"))
        {
        if (Physics.Raycast(transform.position, fwd, out hit, layer))
                //Destroy(hit.transform.gameObject);
            hit.collider.gameObject.GetComponent<EnemyMov>().damaged = true;
            score = score + 50;
            //hit.collider.SendMessageUpwards("damaged");
        }
    }

    public void setBonusScore()
    {
        bonusScore -= 100;
        bonusText.text = "Bonus: " + bonusScore.ToString();
        if (bonusScore == 0)
        {
            CancelInvoke("setBonusScore");
        }
        if (gameOver)
        {
            score += bonusScore;
            CancelInvoke("setBonusScore");
            scoreValue.text = "Score: " + score.ToString();
        }
    }
    public float setScore(float s)
    {
        score += s;
        scoreValue.text = "Score: " + score.ToString();
        return score;
    }

    public float setEnemies(float e)
    {
        enemies -= e;
        enemiesText.text = "Enemies: " + enemies.ToString();
        return enemies;
    }
}
