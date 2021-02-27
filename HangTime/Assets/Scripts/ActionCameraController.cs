using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCameraController : MonoBehaviour
{

    public Transform PlayerTransform;

    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = .05f;

    public bool RotateAroundPlayer = true;

    public float RotationSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - PlayerTransform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(RotateAroundPlayer)
        {
            Quaternion camTurnAngleX = 
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up); 

            Quaternion camTurnAngleY = 
                Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * RotationSpeed, Vector3.right); 

            cameraOffset = camTurnAngleX * camTurnAngleY * cameraOffset;
        }

        Vector3 newPos = PlayerTransform.position + cameraOffset; 
    
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
        
        transform.LookAt(PlayerTransform);
    }
}
