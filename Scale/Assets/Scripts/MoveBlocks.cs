using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocks : MonoBehaviour
{
    [SerializeField]
    private float forceMagnitude;

    void OnControllerColliderHit(ControllerColliderHit hit) {

        Rigidbody rb = hit.collider.attachedRigidbody;

        if (rb != null) {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rb.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
        }
    }
}
