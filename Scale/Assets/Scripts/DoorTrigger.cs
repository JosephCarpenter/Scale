using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    
    bool isOpened = false;
    
    void OnTriggerEnter(Collider col) {
        if (!isOpened && col.transform.localScale.x >= 2) {
            door.transform.position += new Vector3(0, 4, 0);
            this.transform.position += new Vector3(0, -0.25f, 0);
            isOpened = true;
        }
    }
    
}
