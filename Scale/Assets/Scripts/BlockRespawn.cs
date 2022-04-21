using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRespawn : MonoBehaviour
{
    private Vector3 originalPos;

    private bool reset = false;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    void Update() {
        if (Input.GetKeyUp("r")) {
            reset = true;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (reset) {
            transform.position = originalPos;
            reset = false;
        }
    }
}
