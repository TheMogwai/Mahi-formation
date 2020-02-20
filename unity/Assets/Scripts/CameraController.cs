using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CameraController : MonoBehaviour
{
#if UNITY_EDITOR
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;
    public bool MouseControlled = false;
    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    void Start()
    {
        if (!MouseControlled)
        {
            GetComponent<Camera>().stereoTargetEye = StereoTargetEyeMask.Both;
           return;
        }
        GetComponent<Camera>().stereoTargetEye = StereoTargetEyeMask.None;
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    void Update()
    {
        if (MouseControlled)
        {
            Cursor.visible = true;

            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = -Input.GetAxis("Mouse Y");

            rotY += mouseX * mouseSensitivity * Time.deltaTime;
            rotX += mouseY * mouseSensitivity * Time.deltaTime;

            rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

            Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
            transform.rotation = localRotation;
        }
    }

    
#endif
}
