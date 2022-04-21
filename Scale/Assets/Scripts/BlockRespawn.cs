using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRespawn : MonoBehaviour
{
    private Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyUp("r")) {
            transform.position = originalPos;
        }
    }
}
