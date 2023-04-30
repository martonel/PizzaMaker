using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Vector3 movementDirection = Vector3.zero;

    private CharacterController controller;
    public Animator animator;
    private bool isStartMove = false;
    public DragAndDropp dragAndDropp;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movementDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        if (movementDirection.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(movementDirection);
            if(!dragAndDropp.GetGrabbed()){
                animator.SetBool("IsRunning", true);// play "Run" animation
            }
        }
        else
        {
            if(!dragAndDropp.GetGrabbed()){
                animator.SetBool("IsRunning", false); // stop "Run" animation
            }
        }

        movementDirection *= moveSpeed;
        controller.Move(movementDirection * Time.deltaTime);
    }

    void LateUpdate()
    {
        if (movementDirection.magnitude < 0.01f && !dragAndDropp.GetGrabbed())
        {
            controller.SimpleMove(Vector3.zero);
            animator.SetBool("IsRunning", false); // stop "Run" animation
            animator.Play("Optional"); // play "Optional" animation
        }
    }
}