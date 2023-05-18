using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float gravity = -9.81f;
    public CharacterController characterController;

    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        //Movement control
        Vector3 move = transform.right * x *3 + transform.forward * z *3;
        characterController.Move(Time.deltaTime * walkingSpeed * move);

        // Gravity control
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}

