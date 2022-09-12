using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public bool attack;
    public LayerMask layer;
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);

        var target = GameObject.Find ("Crosshair");

        target.transform.position = new Vector3 (pos.x, pos.y, -9);

        print(this.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));


        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        //var EnemyAI : enemy = hit.collider.GetComponent(EnemyAI);
        //layer = LayerMask.NameToLayer("Enemy");
        if (Input.GetButtonDown("Fire1"))
        {
        if (Physics.Raycast(transform.position, fwd, out hit, layer))
                //Destroy(hit.transform.gameObject);
            hit.collider.gameObject.GetComponent<EnemyMov>().damaged = true;
            //hit.collider.SendMessageUpwards("damaged");
        }
    }
}
