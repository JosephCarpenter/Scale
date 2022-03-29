// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// 
// // Include the namespace required to use Unity UI and Input System
// using UnityEngine.InputSystem;
// using TMPro;
// 
// public class PlayerController : MonoBehaviour {
// 
// 	// Create public variables for player speed, and for the Text UI game objects
// 	public float speed;
// 	// public TextMeshProUGUI countText;
// 	// public GameObject winTextObject;
// 
//     private float movementX;
//     private float movementY;
// 
// 	private Rigidbody rb;
// 	private int count;
// 
// 	// At the start of the game..
// 	void Start () {
// 		// Assign the Rigidbody component to our private rb variable
// 		rb = GetComponent<Rigidbody>();
// 
// 		// Set the count to zero 
// 		count = 0;
// 
// 		// SetCountText();
//         // // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
//         // winTextObject.SetActive(false);
// 	}
// 
// 	void FixedUpdate () {
// 		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
// 		Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
// 
// 		rb.AddForce(movement * speed);
// 	}
// 
// 	void OnTriggerEnter(Collider other) {
// 		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
// 		if (other.gameObject.CompareTag ("Pickup"))
// 		{
// 			other.gameObject.SetActive (false);
// 
// 			// Add one to the score variable 'count'
// 			count = count + 1;
// 
// 			// Run the 'SetCountText()' function (see below)
// 			// SetCountText ();
// 		}
// 	}
// 
//     void OnMove(InputValue value) {
//     	Vector2 v = value.Get<Vector2>();
// 
//     	movementX = v.x;
//     	movementY = v.y;
//     }
// 
//     // void SetCountText() {
// 	// 	countText.text = "Count: " + count.ToString();
//     // 
// 	// 	if (count >= 9) 
// 	// 	{
//     //         // Set the text value of your 'winText'
//     //         winTextObject.SetActive(true);
// 	// 	}
// 	// }
// }

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

    private void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    void Update()
    {
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
}