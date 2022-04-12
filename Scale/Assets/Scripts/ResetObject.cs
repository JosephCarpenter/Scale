using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour
{

  public GameObject cube;
  public Vector3 orignalPos;
    // Start is called before the first frame update
    void Start()
    {
      orignalPos = gameObject.transform.position;
      cube = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
      if(cube.transform.position.y < -8){
          gameObject.transform.position = orignalPos;
        }
    }
}
