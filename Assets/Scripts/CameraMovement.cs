using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Time.timeScale = 1.5f;
            Debug.Log("ButtonPressed");
        }
        else
        {
            Time.timeScale = 1;
        }

        Camera.main.gameObject.transform.position = cameraPosition;
    }
}
