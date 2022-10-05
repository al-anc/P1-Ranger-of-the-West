using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    public int timer;
    public int timer2;
    public bool Active;
    private bool Escape;
    public bool damaged;
    public Vector3 TransformPosition;
    public int speed;
    private bool move;
    private Vector3 start;
    public bool Attack;
    public int Strength;
    private bool Speedup;
    public GameObject Player;
    public GameObject Points;
    private bool isNull;
    public AudioSource audiosource;
    public AudioClip collectedClip;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        Active = false;
        //Goal = this.gameObject.transform.GetChild(0);
        damaged = false;
        Attack = false;
        TransformPosition.z = transform.position.z;
        isNull = false;
    }

        public void PlaySound(AudioClip clip)
  {
    audiosource.PlayOneShot(clip);
  }

    //Update is called once per frame
    void Update()
    {
        if (!isNull)
        {
            StartCoroutine(ExecuteAfterTime(timer));
            if (Speedup == true)
            {
                //timer = timer-10;
            }
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (damaged == true && !isNull)
        {
            AddPoints();
            Escape = true;
            Die();

        }
        if (Active == true && !isNull) {move = true;}

        if (Escape == true && !isNull) {move = false;}
        
        if (Attack == true && !isNull)
        {
            //THIS IS WHERE YOU PUT IN THE SCORE
            Player.GetComponent<PlayerController>().score = Player.GetComponent<PlayerController>().score - Strength;
        }

        if (move == true && !isNull)
        {
            float step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, TransformPosition, step);
        }
        else if (move == false && !isNull)
        {
            float step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, start, step);            
        }
        if (Active = false && !isNull)
        {
            //transform.Translate(-Goalx, -Goaly, 0);
        }
    }
        IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
		Active = true;
        Debug.Log("Active");
        StartCoroutine(ExecuteAfterTime2(timer2));
	}
        IEnumerator ExecuteAfterTime2(float time)
    {
        yield return new WaitForSeconds(time);
        Active = false;
        Attack = true;
        Escape = true; 
        Destroy(gameObject, 1);
	}
    void AddPoints()
    {
        Player.GetComponent<PlayerController>().setScore(150);
        Player.GetComponent<PlayerController>().setEnemies(1);
    }

    void Die()
    {
            PlaySound(collectedClip);
            Points.SetActive(true);
            transform.Translate(start);
            if (Points.activeInHierarchy == true)
            {
                Destroy(Points, 0.2f);
                //Points = null;
            }
            isNull = true;
            Destroy(gameObject, 1);

    }
}
