using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed;
    public float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public float playerSize = 1.0f;

    private void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        updateScale();
        
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    
    void updateScale() {
        if (Input.GetMouseButtonDown(0)) {
            playerSize += 0.1f;
        } else if (Input.GetMouseButtonDown(1)) {
            playerSize -= 0.1f;
        }        
        
        gameObject.transform.localScale = new Vector3(playerSize, playerSize, playerSize); 
    }
}