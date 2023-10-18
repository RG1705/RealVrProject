using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //lock cursor in middle
        Cursor.visible = false; //make cursor invisible
    }


    private void Update()
    {
        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;


        // how unity handles rotations and inputs
        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Can't look up or down more than 90 degrees

        // rotate cam and orientatation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); // rotates camera on both x and y axis
        orientation.rotation = Quaternion.Euler(0, yRotation, 0); // rotates player on y axis

    }
}