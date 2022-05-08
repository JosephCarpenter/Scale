using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EndGameCheckPoint : MonoBehaviour
{
    public bool activated = false;
    public static GameObject[] CheckPointsList;
    public GameObject player;

    public GameObject enemy;

    public bool reset = false;
    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        CheckPointsList = GameObject.FindGameObjectsWithTag("EndGameCheckPoint");

    }

    void Update() {
        resetGame();
        if (player.transform.position.y < -10){

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
        if (dead) {

            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = GetActiveCheckPointPosition();

            enemy.transform.position = GetActiveCheckPointPosition();
            enemy.transform.position = new Vector3(enemy.transform.position.x + 10, enemy.transform.position.y, enemy.transform.position.z);
            dead = false;
        }
    }
    // Activate the checkpoint
    private void ActivateCheckPoint()
    {
        // We deactive all checkpoints in the scene
        foreach (GameObject cp in CheckPointsList)
        {
            cp.GetComponent<EndGameCheckPoint>().activated = false;
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
                if (cp.GetComponent<EndGameCheckPoint>().activated)
                {
                    result = cp.transform.position;
                    break;
                }
            }
        }

        return result;
    }


    void resetGame() {
        GameObject player = GameObject.FindGameObjectWithTag("player");
        if (Math.Abs(player.transform.position.x - enemy.transform.position.x) <= 2 
            && Math.Abs(player.transform.position.z - enemy.transform.position.z) <= 2
            && Math.Abs(player.transform.position.y - enemy.transform.position.y) <= 2) {
                dead = true;
            }
    }
}
