using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumbTrigger : MonoBehaviour
{
  public float weight;
  public GameObject cube;
  public GameObject floor;
  private Vector3 originalPosCrumb;
  private Vector3 originalPosCube;
    // Start is called before the first frame update
    void Start()
    {
      cube = GameObject.FindGameObjectWithTag("player");
      originalPosCrumb = floor.transform.position;
      originalPosCube = cube.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
      weight = cube.GetComponent<PlayerController>().playerSize;
      if(floor.transform.position.y < -8){
        floor.GetComponent<Rigidbody>().useGravity = false;
        floor.GetComponent<Rigidbody>().isKinematic = true;
        floor.gameObject.transform.position = originalPosCrumb;
        cube.transform.position = originalPosCube;
        floor.GetComponent<Rigidbody>().isKinematic = false;
    }

    void OnTriggerStay(Collider other){
      Debug.Log("worked");
      if(other.gameObject.tag == "player" && weight > 1f){
          Invoke("fallDown", 0.2f);
      }
    }

    void fallDown(){
      floor.GetComponent<Rigidbody>().useGravity = true;
      // Invoke("resetPos", 3f);
    }
  }
}
