using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFollowMouse : MonoBehaviour
{
    private bool isDragging;
    private Vector3 dragStartPos;
    private float dragSpeed = 4;

    void Update()
    {
        // Kiểm tra chuột có được giữ không
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    isDragging = true;
                    dragStartPos = Input.mousePosition;
                }
            }
        }

        // Xoay object khi chuột được giữ và di chuyển
        if (isDragging && Input.GetMouseButton(0))
        {
            float dragDistance = (Input.mousePosition - dragStartPos).x;
            float yaw = dragDistance * dragSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, yaw, Space.World);
            dragStartPos = Input.mousePosition;
        }

        // Ngừng xoay khi chuột ngừng di chuyển
        if (isDragging && Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }
}
