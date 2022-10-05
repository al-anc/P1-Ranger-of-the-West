using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

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
    public GameObject GameOverMenu;
    public bool Paused;
    public bool attack;
    public LayerMask layer;
    public GameObject Crosshair;
    public GameObject Enemy;
    public Camera cam;
    [SerializeField]
    private PlayerInput playerControls;
    private RangerOfTheWestActions Actions;

    public bool gameOver;

    void Awake()
    {
        Time.timeScale = 1;
        playerControls = GetComponent<PlayerInput>();
        Actions = new RangerOfTheWestActions();
    }

    private void OnEnable()
    {
        playerControls.actions["Fire"].performed += Fire;
        playerControls.actions["Pause"].performed += Pause;
        Actions.Enable();
    }

    private void OnDisable()
    {
        playerControls.actions["Fire"].performed -= Fire;
        playerControls.actions["Pause"].performed -= Pause;
        Actions.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        enemies = 51;
        bonusScore = 15000;
        InvokeRepeating("setBonusScore", 1, 1);

        scoreValue.text = ("0000000" + score.ToString());
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
            GameOverMenu.SetActive(true);
            gameOver = true;
            enemiesText.text = ("Enemies: " + enemies.ToString());
            gameOverText.text = ($"Game Over! Final Score: {score} Press Esc to exit game.");
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log ("Game Closed");
            Application.Quit();
        }
        //     RaycastHit hit;
        //         bool Fire = Actions.Player.Fire.ReadValue<float>() > 0.4f;
        //         if(Fire)
        // {
        // Ray ray = cam.ScreenPointToRay(Crosshair.transform.position);
        //     if (Physics.Raycast(ray, out hit, 1000, layer))
        //     {
        //         Debug.Log("Raycast shot");
        //         EnemyMov enemy = hit.transform.GetComponent<EnemyMov>();
        //         if (enemy != null && !enemy.damaged)
        //         {
        //             Destroy(enemy.GetComponent<Collider>());
        //             enemy.damaged = true;
        //         }
        //         Debug.Log("Fired");
        //         //hit.collider.SendMessageUpwards("damaged");
        //     }
        //     else
        //     {
        //         Debug.Log("Missed");
        //     }
        // }


        Vector3 fwd = Crosshair.transform.TransformDirection(Vector3.forward);
        //var EnemyAI : enemy = hit.collider.GetComponent(EnemyAI);
        //layer = LayerMask.NameToLayer("Enemy");
        // if (Input.GetButtonDown("Fire1"))
        // {
        //     Ray ray = cam.ScreenPointToRay(Crosshair.transform.position);
        //     if (Physics.Raycast(ray, out hit, 1000, layer))
        //     {
        //         Debug.Log("Raycast shot");
        //         EnemyMov enemy = hit.transform.GetComponent<EnemyMov>();
        //         if (enemy != null && !enemy.damaged)
        //         {
        //             Destroy(enemy.GetComponent<Collider>());
        //             enemy.damaged = true;
        //         }
        //         Debug.Log("Fired");
        //         //hit.collider.SendMessageUpwards("damaged");
        //     }
        //     else
        //     {
        //         Debug.Log("Missed");
        //     }
                
        // }

        if(score >= 100){
            scoreValue.text = "00000" + score.ToString();
            }

        if(score >= 1000){
            scoreValue.text = "0000" + score.ToString();
            }

        if(score >= 10000){
            scoreValue.text = "000" + score.ToString();
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
    private void Fire(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Crosshair.transform.position);
        if (Physics.Raycast(ray, out hit, 1000, layer))
        {
            Debug.Log("Raycast shot");
            EnemyMov enemy = hit.transform.GetComponent<EnemyMov>();
            if (enemy != null && !enemy.damaged)
            {
                Destroy(enemy.GetComponent<Collider>());
                enemy.damaged = true;
            }
            Debug.Log("Fired");
            //hit.collider.SendMessageUpwards("damaged");
        }
        else
        {
            Debug.Log("Missed");
        }

    }
    private void Pause(InputAction.CallbackContext context)
    {
        if (Paused == false)
        {
            Pausemenu.SetActive(true);
            Paused = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Paused == true)
        {
            Pausemenu.SetActive(false);
            Paused = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            if (Paused == false)
            {
                Pausemenu.SetActive(false);
            }
        }
    }
}
