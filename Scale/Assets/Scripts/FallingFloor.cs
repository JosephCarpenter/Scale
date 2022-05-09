using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
  public float weight;
  private GameObject cube;
  public GameObject floor;
  public Vector3 originalPosCrumb;
  public Vector3 originalPos;
  public Vector3 target;
  public float speed;
  public bool plate;
    // Start is called before the first frame update
    void Start()
    {
      cube = GameObject.FindGameObjectWithTag("player");
      originalPosCrumb = floor.transform.position;
      originalPos = gameObject.transform.position;
      target = new Vector3(originalPosCrumb.x, -100, originalPosCrumb.z);
      plate = false;
    }

    // Update is called once per frame
    void Update()
    {
      weight = cube.GetComponent<PlayerController>().playerSize;
     
    }

    void OnTriggerStay(Collider other){
      if(other.gameObject.tag == "player"){
        if(weight > 1f || !plate){
          speed = .1f;
          var step =  speed;
          floor.transform.position = Vector3.MoveTowards(floor.transform.position, target, step);
          transform.position = Vector3.MoveTowards(transform.position, target, step);
          // Invoke("fallDown", 0.2f);
        }
      }
    }


    void fallDown(){
      // speed = .1f;
      // var step =  speed;
      // floor.transform.position = Vector3.MoveTowards(floor.transform.position, target, step);
      // transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
}
