using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static float score;
    public float bonusScore;
    public float enemies;

    public Text scoreValue;
    public Text bonusText;
    public Text enemiesText;

    public bool gameOver;

    

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        enemies = 20;
        bonusScore = 5000;
        InvokeRepeating("setBonusScore", 1, 1);

        scoreValue.text = ("Score: " + score.ToString());
        bonusText.text = ("Bonus: " + bonusScore.ToString());
        enemiesText.text = ("Enemies " + enemies.ToString());
        
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setBonusScore()
    {
        bonusScore -= 100;
        bonusText.text = "Bonus " + bonusScore.ToString();
        if (bonusScore == 0)
        {
            CancelInvoke("setBonusScore");
        }
        if (gameOver)
        {
            score += bonusScore;
            CancelInvoke("setBonusScore");
            scoreValue.text = "Score " + score.ToString();
        }
    }
}
