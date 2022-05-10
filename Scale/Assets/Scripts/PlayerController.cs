using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed;
    public float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public float playerSize = 1.0f;
    private bool jumped = false;
    public AudioSource walking;
    public AudioSource shrinking;
    public AudioSource pushing;
    public AudioSource againstBlock;

    private void Start()
    {
        walking.loop = true;
        walking.Play(0);
        pushing.loop = true;
        // pushing.Play(0);
        // pushing.Pause();
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
            walking.UnPause();
            gameObject.transform.forward = move;
        }
        else {
            walking.Pause();
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            // Vector3 jumper = new Vector3(playerSize*2f, playerSize*.5f, playerSize*2f);
            // LeanTween.scale(gameObject, jumper, 1.5f).setEaseOutCubic();
            GetComponentInChildren<Animator>().SetTrigger("Stretch");
            jumped = true;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue * (1 / playerSize));
        }

        if (Input.GetKeyDown("left shift")) {
            playerSpeed *= 2;
        }

        if (Input.GetKeyUp("left shift")) {
            playerSpeed /= 2;
        }


        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);




    }

    void updateScale() {
        if (Input.GetKeyDown("q")) {
            if (playerSize == 3f) {
                playerSize = 2f;
                shrinking.Play();
            }
            else if (playerSize == 2f) {
                playerSize = 1f;
                shrinking.Play();
            }
            else {
                return;
            }
        }
        Vector3 scale = new Vector3(playerSize, playerSize, playerSize);
        LeanTween.scale(gameObject, scale, 1.5f).setEaseOutElastic();
        // gameObject.transform.localScale = new Vector3(playerSize, playerSize, playerSize);
    }

    // acts to grow the size to one of three different sizes if you are in water
    void OnTriggerStay(Collider other) {
        if (other.tag == "water") {
            if (Input.GetKeyDown("e")) {
                if (playerSize == 1f) {
                    playerSize = 2f;
                }
                else if (playerSize == 2f) {
                    playerSize = 3f;
                }
                else {
                    return;
                }
                gameObject.transform.localScale = new Vector3(playerSize, playerSize, playerSize);
            }
        }
    }


    void OnControllerColliderHit(ControllerColliderHit hit) {
      if (jumped){
        jumped = false;
        GetComponentInChildren<Animator>().SetTrigger("Squash");
      }
    }
    
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "cube") { 
            // transform.localScale = new Vector3(6f, 6f, 6f);
            Debug.Log("Collided");
            // if (playerSize < other.transform.localScale.x) {
            //     againstBlock.Play();
            // }
            // else {
            //     pushing.UnPause();
            // }
        }
    }
    
    void OnCollisionExit(Collision other) {
        pushing.Pause();
    }


}
