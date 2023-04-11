using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float rotateSpeed = 5f; // Tốc độ xoay
    public float minYAngle = -90f; // Góc xoay tối thiểu
    public float maxYAngle = 90f; // Góc xoay tối đa
    public float minXAngle = -90f; // Góc xoay tối thiểu
    public float maxXAngle = 90f; // Góc xoay tối đa
    private float currentX; // Góc xoay hiện tại trên trục y
    private float currentY; // Góc xoay hiện tại trên trục x
    private bool isRotating = false; // Kiểm tra chuột có đang giữ hay không

    private void Start()
    {
        currentX = transform.rotation.x;
        currentY = transform.rotation.y;
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) // Nếu chuột trái được nhấn
        {
            isRotating = true; // Đang xoay
        }

        if (Input.GetMouseButtonUp(0)) // Nếu chuột trái được nhả
        {
            isRotating = false; // Không xoay nữa
        }

        if (isRotating) // Nếu đang xoay
        {
            currentX += Input.GetAxis("Mouse X") * rotateSpeed; // Lấy giá trị di chuyển của chuột theo trục x
            currentY -= Input.GetAxis("Mouse Y") * rotateSpeed; // Lấy giá trị di chuyển của chuột theo trục y

            currentX = Mathf.Clamp(currentX, minXAngle, maxXAngle);
            currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle); // Giới hạn góc xoay trên trục x

            transform.rotation = Quaternion.Euler(currentY, -currentX, 0f); // Xoay camera theo góc xoay hiện tại
        }
    }
}
