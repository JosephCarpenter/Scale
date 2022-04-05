using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxWeight : MonoBehaviour
{
    public GameObject player;
    private PlayerController player_script;
    private RigidbodyConstraints unfreeze;
     
    // Start is called before the first frame update
    void Start()
    {
        player_script = player.GetComponent<PlayerController>();
        unfreeze = GetComponent<Rigidbody>().constraints;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        
        if (player_script.playerSize != 3f) {
            rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        } else if (player_script.playerSize == 3f) {
            rigidbody.constraints = unfreeze;
        }
    }
}
