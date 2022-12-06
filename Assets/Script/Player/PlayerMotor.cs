using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed;

    private bool isGrounded;
    public float gravity;

    public float jumpHeight;
    //Gun animate
    public SCARanimation SCAR;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = controller.isGrounded;//

    }
    public void ProcessMove(Vector2 input) //reieve input for InputManager and apply for character controller
    {
        Vector3 moveDirection = Vector3.zero;

        moveDirection.x = input.x;
        moveDirection.z = input.y;

        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y < 0)//
        {
            playerVelocity.y = -2f;
        }
            

        controller.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(playerVelocity.y);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 10;
            

        }
        else
        {
            speed = 5;
        }
    }
    public void Jump()
    {
        if(isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}
