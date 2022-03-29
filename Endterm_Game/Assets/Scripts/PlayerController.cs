using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;
//using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 30.0f;
    public Camera playerCamera;
    public float lookSpeed = 100.0f;
    public float lookXLimit = 25.0f;
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;



    float mouseX = 0.0f;
    float mouseY = 0.0f;


    [HideInInspector]
    public bool canMove = true;
  //  float halfScreenWidth;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }

    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = false;
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        //if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        //{
        //    moveDirection.y = jumpSpeed;
        //}
        //else
        //{
        //    moveDirection.y = movementDirectionY;
        //}

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity /** Time.deltaTime*/;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");



        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -mouseY * lookSpeed * Time.deltaTime;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

            transform.rotation *= Quaternion.Euler(0, mouseX * lookSpeed * Time.deltaTime, 0);
        }
    }

}
