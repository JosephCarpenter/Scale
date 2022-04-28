using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public GameObject enemy;
    private Transform target;
    
    public float speed;

    private bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>(); 
    }

    void Update()
    {
        if (start) {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target.position, speed * Time.deltaTime); 
            enemy.transform.LookAt(target.position);
        }
    
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "player") {
            start = true;
        }
    }

}
