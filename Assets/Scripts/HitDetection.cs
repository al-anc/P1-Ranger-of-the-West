using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver(){
        if (Input.GetMouseButtonDown (0)){
            print ("CLICK");
            //gameObject.GetComponent<EnemyMov>().damaged = true;
        }
    }
}
