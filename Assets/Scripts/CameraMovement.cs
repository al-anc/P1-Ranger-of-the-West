using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private PlayerController pC;
    [SerializeField]
    private RangerOfTheWestActions playerInput;
    private InputAction sprint;
    private InputAction sprintEnd;
    [SerializeField]
    private bool isSprinting;
    
    
    private void Awake()
    {
        playerInput = new RangerOfTheWestActions();
    }

    private void OnEnable()
    {
        sprint = playerInput.Player.Sprint;
        sprint.Enable();
        sprint.performed += Sprint;

        sprintEnd = playerInput.Player.SprintEnd;
        sprintEnd.Enable();
        sprintEnd.performed += SprintEnd;
    }

    private void OnDisable()
    {
        sprint.Disable();
        sprintEnd.Disable();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        isSprinting = false;
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        var cameraPosition = Camera.main.gameObject.transform.position;
        cameraPosition.x +=Time.deltaTime*speed;
        if (!pC.gameOver)
        {
            if (isSprinting && !pC.Paused)
            {
                Time.timeScale = 1.5f;
            }
            else if (pC.Paused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        } 
            

        Camera.main.gameObject.transform.position = cameraPosition;
    }
    private void Sprint(InputAction.CallbackContext context)
    {
        isSprinting = true;
    }

    private void SprintEnd(InputAction.CallbackContext context)
    {
        isSprinting = false;
    }
}
