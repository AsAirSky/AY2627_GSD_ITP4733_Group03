using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerControl : NetworkBehaviour

{
    private float walkSpeed = 6f;
    private float turnSpeed = 90;

    private Animator animator;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (IsClient && IsOwner)
        {



            //turn
            float rotate = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up * rotate);


            //move
            float forward = Input.GetAxis("Vertical") * walkSpeed * Time.deltaTime;
            transform.position = transform.forward * forward;
            characterController.Move(transform.forward * forward);

            animator.SetFloat("Walk", Input.GetAxis("Vertical"));
        }
    }
}
