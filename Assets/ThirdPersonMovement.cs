using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    //motor that drives our player
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move around using WASD and arrows keys
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //storing direction 
        //normalize : if we press down two keys at the same time so the speed is not doubled
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //if we're moving in any direction
        if(direction.magnitude >= 0.1f)
        {

            //rotating player towards the direction 
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            //smoothing numbers and angles
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            //rotation we move in account to the rotation of cam
            Vector3 moveDir= Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //input to move
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

        }


    }
}
