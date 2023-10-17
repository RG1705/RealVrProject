using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamforPlayer : MonoBehaviour
{
    public float sensX;
    public float sensY;


    public Transform orientation;


    float xRotation;
    float yRotation;

    private void Start()
    {
        //make sure cursor doesnt move when moving the player and having it not show up
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void Update()
    {
        // get mouse input 
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        
        yRotation += mouseX;
        xRotation -= mouseY;

        //character does not look up or down more than 90 degrees
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate camera and orientation properly
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
