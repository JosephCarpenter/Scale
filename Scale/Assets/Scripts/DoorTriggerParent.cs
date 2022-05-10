using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerParent : MonoBehaviour
{
    [SerializeField]
    public GameObject door;
    public Component[] plates;
    
    Vector3 doorDefaultPos;
    
    public AudioSource doorOpenAudio;
    public AudioSource doorCloseAudio;
    private bool statusChanged;
    private bool doorRaised;

    void Start()
    {
        doorRaised = true;
        statusChanged = false;
        doorDefaultPos = door.transform.position;
        plates = GetComponentsInChildren<DoorTrigger>();
    }

    void Update()
    {
        bool raiseDoor = true;
        foreach (DoorTrigger plate in plates) {
            if (!plate.isOpened) {
                raiseDoor = false;
            }
        }
        if (raiseDoor) {
            if (!doorRaised)
                statusChanged = true;
            doorRaised = true;
        }
        else {
            if (doorRaised)
                statusChanged = true;
            doorRaised = false;
        }
        if (doorRaised) {
            door.transform.position = doorDefaultPos + new Vector3(0, 2, 0);
            if (statusChanged)
                doorOpenAudio.Play();
        }
        else {
            door.transform.position = doorDefaultPos;
            if (statusChanged)
                doorCloseAudio.Play();
        }
        statusChanged = false;
    }   
}
