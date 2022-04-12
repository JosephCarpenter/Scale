using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerParent : MonoBehaviour
{
    [SerializeField]
    public GameObject door;
    public Component[] plates;
    
    Vector3 doorDefaultPos;

    void Start()
    {
        doorDefaultPos = door.transform.position;
        plates = GetComponentsInChildren<DoorTrigger>();
    }

    void Update()
    {
        bool raiseDoor = true;
        foreach (DoorTrigger plate in plates) {
            if (!plate.isOpened)
                raiseDoor = false;
        }
        if (raiseDoor) {
            door.transform.position = doorDefaultPos + new Vector3(0, 4, 0);
        }
        else {
            door.transform.position = doorDefaultPos;
        }
    }   
}
