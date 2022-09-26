using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public bool attack;
    public LayerMask layer;
    public LayerMask layer2;
    public GameObject Enemy;
    public GameObject Hostage;
    public Camera camera;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
            //Player.GetComponent<PlayerController>().score;
            //hit.collider.SendMessageUpwards("damaged");
            if (Physics.Raycast(transform.position, fwd, out hit, layer2))
                //Destroy(hit.transform.gameObject);
                hit.collider.gameObject.GetComponent<EnemyMov>().damaged = true;
        }
    }
}
