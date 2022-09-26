using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Start ()
    {

    }

    private void Update()
    {
        Vector2 move = playerControls.Shooter.Move.ReadValue<Vector2>();
        Debug.Log(move);
        if (playerControls.Shooter.Shoot.triggered)
            Debug.Log("Shot");
    }
}
