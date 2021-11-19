using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private float cameraRotationSpeed;
    
    void Update()
    {
        if (!Input.GetMouseButton(0)) return;
        camera.transform.eulerAngles += cameraRotationSpeed * new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f).normalized;
        
    }
}
