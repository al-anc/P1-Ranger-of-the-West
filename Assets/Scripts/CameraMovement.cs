using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        var cameraPosition = Camera.main.gameObject.transform.position;
        cameraPosition.x +=Time.deltaTime*speed;
        if (Input.GetButton("Sprint"))
        {
            speed = 8;
            Debug.Log("ButtonPressed");
        }
        else
        {
            speed = 2;
        }

        Camera.main.gameObject.transform.position = cameraPosition;
    }
}
