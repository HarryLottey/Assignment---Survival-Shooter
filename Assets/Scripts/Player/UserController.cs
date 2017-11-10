using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour
{
    /// Apply defined input
    
    
    public PlayerController playerInput;
    public GameObject gameMasterReference;
    InGamePauseMenu pauseboi;

    // Keyboard
    float kH; 
    float kV; 
    bool j; 

    

    // Use this for initialization
    void Start()
    {

        gameMasterReference = GameObject.FindGameObjectWithTag("GM");
        playerInput = GetComponentInChildren<PlayerController>();
        pauseboi = gameMasterReference.GetComponentInChildren<InGamePauseMenu>();
        Cursor.visible = false;

        
    }

    
    void Update()
    {

        kH = Input.GetAxis("Horizontal");
        kV = Input.GetAxis("Vertical");
        j = Input.GetButton("Jump");

        // Mouse Look
        float mouseX = Input.GetAxis("Mouse X") * playerInput.mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * playerInput.mouseSensitivity;



        if(pauseboi.paused == false) // If the game isnt paused, allow input
        {
            // Gamepad

            /// float gH = Input.GetAxis("");
            /// float gV = Input.GetAxis("");

            // Apply Keyboard movement
            playerInput.KeyboardMove(kH, kV);
            playerInput.Jump(j);

            // Apply MouseLook
            playerInput.CameraLook(mouseX, mouseY);
        }
        

    }
}
