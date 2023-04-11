using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectWithMouse : MonoBehaviour
{
    private Plane plane;
    private Vector3 offset;
    private bool isDragging = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Check if raycast from Screen hit transform ?
                if (hit.transform == transform)
                {
                    plane = new Plane(Vector3.up, transform.position);

                    // create a ray from screen to mouse position
                    Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                    // distance from screen to collision point
                    float rayDistance;
                    // get collision position between plane and ray
                    if (plane.Raycast(camRay, out rayDistance))
                    {
                        // caculate distance from drag object to collsion position
                        offset = transform.position - camRay.GetPoint(rayDistance);
                        isDragging = true;
                    }
                }
            }
        }

        if (isDragging && Input.GetMouseButton(0))
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (plane.Raycast(camRay, out rayDistance))
            {
                transform.position = camRay.GetPoint(rayDistance) + offset;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

}
