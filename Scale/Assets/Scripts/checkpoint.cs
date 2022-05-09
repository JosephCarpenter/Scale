using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public bool activated = false;
    public static GameObject[] CheckPointsList;
    public GameObject player;

    public bool reset = false;

    // Start is called before the first frame update
    void Start()
    {
        CheckPointsList = GameObject.FindGameObjectsWithTag("CheckPoint");

    }

    void Update() {
        if (Input.GetKeyUp("r")) {
            reset = true;
        }
        if (player.transform.position.y == -10){
          reset = true;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (reset) {
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = GetActiveCheckPointPosition();
            reset = false;
        }
    }
    // Activate the checkpoint
    private void ActivateCheckPoint()
    {
        // We deactive all checkpoints in the scene
        foreach (GameObject cp in CheckPointsList)
        {
            cp.GetComponent<checkpoint>().activated = false;
            // cp.GetComponent<Animator>().SetBool("Active", false);
        }

        // We activate the current checkpoint
        activated = true;
    }

    void OnTriggerEnter(Collider other)
    {
        // If the player passes through the checkpoint, we activate it
        if (other.tag == "player")
        {
            ActivateCheckPoint();
        }
    }

    public static Vector3 GetActiveCheckPointPosition()
    {
        // If player die without activate any checkpoint, we will return a default position
        Vector3 result = new Vector3(0, 0, 0);

        if (CheckPointsList != null)
        {
            foreach (GameObject cp in CheckPointsList)
            {
                // We search the activated checkpoint to get its position
                if (cp.GetComponent<checkpoint>().activated)
                {
                    result = cp.transform.position;
                    break;
                }
            }
        }

        return result;
    }

}
