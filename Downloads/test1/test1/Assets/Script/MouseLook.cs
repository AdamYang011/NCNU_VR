using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerbody;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // ESC to exit this mode.

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; 
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  //防止轉過頭

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Quaternion是unity中旋轉一定會用到的function
        playerbody.Rotate(Vector3.up * mouseX);  //Vector3.up = (0,1,0), 水平旋轉=旋轉Y軸
    }
}
