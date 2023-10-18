using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float maxRaycastDistance = 10f;
    public GameObject hitObject;

    private void Update()
    {
        Transform cameraTransform = Camera.main.transform;

        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxRaycastDistance))
        {
            hitObject = hit.collider.gameObject;
            //Debug.Log("Hit: " + hitObject.name);


            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green);
        }
        else
        {
            hitObject = null; // Reset if nothing hit
            Debug.DrawRay(ray.origin, ray.direction * maxRaycastDistance, Color.red);
            //Debug.Log("Did not hit anything.");
        }
    }
}