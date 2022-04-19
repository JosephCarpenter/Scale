using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateLevel2 : MonoBehaviour
{
  public GameObject floor;
  private Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
      originalPos = floor.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other){
      floor.transform.position = new Vector3(originalPos.x,-0.261f,originalPos.z);
    }
    void OnTriggerExit(Collider other){
      floor.transform.position = originalPos;
    }

}
