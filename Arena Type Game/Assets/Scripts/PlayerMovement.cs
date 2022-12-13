using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        //animator start
        if (Input.GetButton("Horizontal"))
        {
            animator.SetBool("Running", true);
        }

        else if (Input.GetButton("Vertical"))
        {
            animator.SetBool("Running", true);
        }

        else animator.SetBool("Running", false);


        if(Input.GetButton("Fire1"))
        {
            animator.SetBool("Swinging", true);

        }

        else animator.SetBool("Swinging", false);

        if (Input.GetButton("Fire1") && (Input.GetButton("Horizontal")))
        {
            animator.SetBool("Swinging", true);
            animator.SetBool("Running", false);

        }

        else if (Input.GetButton("Fire1") && (Input.GetButton("Vertical")))
        {
            animator.SetBool("Swinging", true);
            animator.SetBool("Running", false);

        }

        else animator.SetBool("Swinging", false);
        //animator end


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);

        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
