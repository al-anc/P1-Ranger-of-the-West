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
    private RangerOfTheWestActions Actions;


    // Start is called before the first frame update
    void Start()
    {
        Actions = new RangerOfTheWestActions();
    }

        private void OnEnable()
    {
        Actions.Enable();
    }
        private void OnDisable()
        {
            Actions.Disable();
        }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Input.mousePosition;


        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        //var EnemyAI : enemy = hit.collider.GetComponent(EnemyAI);
        //layer = LayerMask.NameToLayer("Enemy");
                bool Fire = Actions.Player.Fire.ReadValue<float>() > 0.4f;
                if(Fire)
        {
        if (Physics.Raycast(transform.position, fwd, out hit, layer))
                //Destroy(hit.transform.gameObject);
            hit.collider.gameObject.GetComponent<EnemyMov>().damaged = true;
            Debug.Log("Hit");
            //Player.GetComponent<PlayerController>().score;
            //hit.collider.SendMessageUpwards("damaged");
            if (Physics.Raycast(transform.position, fwd, out hit, layer2))
                //Destroy(hit.transform.gameObject);
                hit.collider.gameObject.GetComponent<EnemyMov>().damaged = true;
        }
    }
}
