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
    public GameObject Player;
    public GameObject Points;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        Active = false;
        //Goal = this.gameObject.transform.GetChild(0);
        damaged = false;
        Attack = false;
        StartCoroutine(ExecuteAfterTime(timer));
        TransformPosition.z = transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (damaged == true)
        {
            Escape = true; 
            Points.SetActive(true);
            Destroy(gameObject, 1);
            if (Points.activeInHierarchy == true)
            {
                Destroy(Points, 0.2f);
            }
        }
        if (Active == true) {move = true;}

        if (Escape == true) {move = false;}
        
        if (Attack == true)
        {
            //THIS IS WHERE YOU PUT IN THE SCORE
            Player.GetComponent<PlayerController>().score = Player.GetComponent<PlayerController>().score - Strength;
        }

        if (move == true)
        {
            float step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, TransformPosition, step);
        }
        else if (move == false)
        {
            float step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, start, step);            
        }
        if (Active = false)
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
        void OnMouseOver(){
        if (Input.GetMouseButtonDown (0) && damaged == false){
            Player.GetComponent<PlayerController>().setScore(100);
            Player.GetComponent<PlayerController>().setEnemies(1);
            damaged = true;
        }
    }
}
