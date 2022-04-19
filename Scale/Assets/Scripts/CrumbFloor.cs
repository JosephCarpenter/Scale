using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumbFloor : MonoBehaviour
{
    public float weight;
    public GameObject cube;
    private Vector3 originalPosCrumb;
    private Vector3 originalPosCube;

    // Start is called before the first frame update
    void Start()
    {
      cube = GameObject.FindGameObjectWithTag("player");
      originalPosCrumb = gameObject.transform.position;
      originalPosCube = cube.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      weight = cube.GetComponent<PlayerController>().playerSize;
      if(gameObject.transform.position.y < -8){
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        gameObject.transform.position = originalPosCrumb;
        cube.transform.position = originalPosCube;
        GetComponent<Rigidbody>().isKinematic = false;
      }
      // if(cube.transform.position.y < -10){
      //   cube.transform.position = originalPosCube;
      // }

    }

    void OnCollisionEnter(Collision other){
      if(other.gameObject.tag == "player" && weight > 1f){
          Invoke("fallDown", 0.2f);
      }
    }

    void fallDown(){
      GetComponent<Rigidbody>().useGravity = true;
      // Invoke("resetPos", 3f);
    }

    // void resetPos(){
    //   cube = GameObject.FindGameObjectWithTag("player");
    //   GetComponent<Rigidbody>().useGravity = false;
    //   GetComponent<Rigidbody>().isKinematic = true;
    //   gameObject.transform.position = originalPosCrumb;
    //   cube.transform.position = new Vector3(0f, 0f, 0f);
    //   GetComponent<Rigidbody>().isKinematic = false;
    // }
}
