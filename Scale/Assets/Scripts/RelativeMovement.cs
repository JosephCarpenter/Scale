// using UnityEngine;
// using System.Collections;
// 
// [RequireComponent(typeof(CharacterController))] 
// public class RelativeMovement : MonoBehaviour {
// 
//     [SerializeField] private Transform target;
//     public float moveSpeed = 6.0f;
//     private CharacterController _charController;
// 
//     void Start() {
//     _charController = GetComponent<CharacterController>();    
// }
// 
// 
//     void Update() {
//         Vector3 movement = Vector3.zero;    
//         float horInput = Input.GetAxis("Horizontal");
//         float vertInput = Input.GetAxis("Vertical");
//         if (horInput != 0 || vertInput != 0) {    
//             movement.x = horInput * moveSpeed;
//             movement.z = vertInput;
//             Quaternion tmp = target.rotation * moveSpeed;    
//             target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
//             movement = Vector3.ClampMagnitude(movement, moveSpeed);   
//             movement = target.TransformDirection(movement);    
//             target.rotation = tmp;
//             transform.rotation = Quaternion.LookRotation(movement);    
//         }
//         movement *= Time.deltaTime;    
//         _charController.Move(movement);
//     }
// }
// 
// // This script needs a reference to the object to move relative to.
// // Start with vector (0, 0, 0) and add movement components progressively.
// // Only handle movement while arrow keys are pressed.
// // Keep the initial rotation to restore after finishing with the target object.
// // Transform movement direction from local to global coordinates.
// // LookRotation() calculates a quaternion facing in that direction.