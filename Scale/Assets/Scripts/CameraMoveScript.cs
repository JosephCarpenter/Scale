using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{


    public float smoothness;
    public Transform targetObject;
    private Vector3 initalOffset;
    private Vector3 cameraPosition;
    public float sensitivity = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;


    void Start()
    {  
        initalOffset = transform.position - targetObject.position;
    }

    void Update()
    {
        yaw += sensitivity * Input.GetAxis("Mouse X");
        pitch -= sensitivity * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        cameraPosition = targetObject.position + initalOffset;
        transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothness);
    }
 }
//https://www.codinblack.com/how-to-make-the-camera-follow-an-object-in-unity3d/