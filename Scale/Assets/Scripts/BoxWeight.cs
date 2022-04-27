using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxWeight : MonoBehaviour
{
    private GameObject player;
    private PlayerController player_script;
    private RigidbodyConstraints unfreeze;
    private Vector3 orignalPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        player_script = player.GetComponent<PlayerController>();
        unfreeze = GetComponent<Rigidbody>().constraints;
        orignalPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        if (player_script.playerSize < transform.localScale.x) {
            rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        } else if (player_script.playerSize >= transform.localScale.x) {
            rigidbody.constraints = unfreeze;
        }
        if(player.transform.position.y < -8){
            gameObject.transform.position = orignalPos;
          }
    }
}
