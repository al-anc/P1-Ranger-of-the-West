using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2 : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction shootAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        shootAction = playerInput.actions["Shoot"];
        shootAction.ReadValue<float>();

        //playerInput.SwitchActionMap();
        
    }

    // private PlayerControls playerControls;

    // private void Awake()
    // {
    //     playerControls = new PlayerControls();
    // }

    // private void OnEnable()
    // {
    //     playerControls.Enable();
    // }

    // private void OnDisable()
    // {
    //     playerControls.Disable();
    // }

    // void Start ()
    // {

    // }

    // private void Update()
    // {
    //     Vector2 move = playerControls.Shooter.Move.ReadValue<Vector2>();
    //     Debug.Log(move);
    //     if (playerControls.Shooter.Shoot.triggered)
    //         Debug.Log("Shot");
    // }
}
