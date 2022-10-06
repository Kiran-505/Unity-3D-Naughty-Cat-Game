using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    //motor that drives our player
    private CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float animationSpeed = 5.0f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    //Jump speed and gravity
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float fallingSpeed = -5f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Animator animator;

    Vector3 velocity;
    bool isGrounded;
    public bool isEating = false;

    //Makes it so that you can add a jump sound
    public SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator.speed = animationSpeed;
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {

        // Check if player collides with the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        animator.SetBool("is_walking", false);
        
        // if cat is on ground and is not jumping, then set the height to -1
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        //move around using WASD and arrows keys
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //storing direction 
        //normalize : if we press down two keys at the same time so the speed is not doubled
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //Adds physics to jumping

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -1.0f * gravity);
            soundManager.PlayJumpSound();
        }


        //if we're moving in any direction
        if(direction.magnitude >= 0.1f && !isEating)
        {
            // if cat is on ground then play walking animation
            if (isGrounded)
            {
                animator.SetBool("is_walking", true);
            }
            //rotating player towards the direction 
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            //smoothing numbers and angles
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //rotation we move in account to the rotation of cam
            Vector3 moveDir= Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //input to move
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}
