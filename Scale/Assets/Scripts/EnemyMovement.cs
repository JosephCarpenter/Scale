using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject enemy;
    private Transform target;

    private bool isFound = false;
    
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {

 
        enemy.transform.LookAt(target.position);
        
    }


}
/*
// Update is called once per frame
    void Update()
    {
        if (isFound) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.LookAt(target.position);
            enemy.transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime); 
            enemy.transform.LookAt(target.position);
        }
    }
    
    void OnTriggerEnter(Collider other) {
        if (other.tag == "player") {
            Debug.Log("Working1!");
            isFound = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "player") {
            isFound = false;
        }
    }
*/
