using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateFalling : MonoBehaviour
{
  public FallingFloor floor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other){
      floor.plate = true;
    }
    void OnTriggerExit(Collider other){
      floor.plate = false;
    }
}
