using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Same as boxweight except size 2 can now push boxes.
public class BoxWeight2 : MonoBehaviour
{
  public GameObject player;
  private PlayerController player_script;
  private RigidbodyConstraints unfreeze;
  private Vector3 orignalPos;
    // Start is called before the first frame update
    void Start()
    {
      player_script = player.GetComponent<PlayerController>();
      unfreeze = GetComponent<Rigidbody>().constraints;
      orignalPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        if (player_script.playerSize == 1f) {
            rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        } else {
            rigidbody.constraints = unfreeze;
        }
        if(player.transform.position.y < -8){
            gameObject.transform.position = orignalPos;
          }
    }
}
