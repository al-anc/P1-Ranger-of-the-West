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
    public Vector2 TransformPosition;
    public int speed;
    private bool move;
    private Vector2 start;
    public bool Attack;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        Active = false;
        //Goal = this.gameObject.transform.GetChild(0);
        damaged = false;
        Attack = false;
        StartCoroutine(ExecuteAfterTime(timer));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (damaged == true)
        {
            Escape = true; 
            Destroy(gameObject, 1);
        }
        if (Active == true) {move = true;}

        if (Escape == true) {move = false;}
        
        if (Attack == true)
        {

        }

        if (move == true)
        {
            float step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector2.MoveTowards(transform.position, TransformPosition, step);
        }
        else if (move == false)
        {
            float step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector2.MoveTowards(transform.position, start, step);            
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
        if (Input.GetMouseButtonDown (0)){
            damaged = true;
        }
    }
}
