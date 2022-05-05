using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    
    public bool isOpened = false;
    public bool hold = false;
    
    void OnTriggerEnter(Collider col) {
        if (!isOpened && col.transform.localScale.x >= transform.localScale.x) {
            this.transform.position += new Vector3(0, -0.10f, 0);
            isOpened = true;
        }
    }
    
    void OnTriggerExit(Collider col) {
        if (hold && isOpened && col.transform.localScale.x >= transform.localScale.x) {
            this.transform.position -= new Vector3(0, -0.10f, 0);
            isOpened = false;
        }
    }
    
}
