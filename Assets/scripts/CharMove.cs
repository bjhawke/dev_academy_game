﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    //Current charachter's velocity, used for gravity
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    

    //Set Up
    public CharacterController controller;
    public MonsterTrickle monstScript;
    //Properties
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    public bool isSeen;
    public float numReflection; //external mirror count

    public Vector3 thisMirror = new Vector3(1, 1, 1); // start mirror

    public Vector3 lastMirror = new Vector3(1, 1, 1);


    // Start is called before the first frame update
    void Start()
    {
        //controller = gameObject.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        //check if atleast one external mirror is is looking and update global boolean status
        if(numReflection > 0)
        {
            isSeen = true;
        }
        else
        {
            isSeen = false;
        }

        //use inbuilt function of Unity CharachterController script in order to check if the bottom f the mesh is touching a surface
        groundedPlayer = controller.isGrounded;


        //make sure the player loses momentum when the player touches the ground and isnt moving in the y direction
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        //get Unity's "W:S" keys as "Vertical"  and "A:D" keys as "Horizontal" 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        //Accelerate if airborn for gravity effect
        playerVelocity.y += gravityValue * Time.deltaTime;
        
        //Update one Vector3 of all movement with 3 vectors of x,y,z
        Vector3 move = x * Vector3.right + z * Vector3.forward + playerVelocity;

        //get directional vector
        move = transform.TransformDirection(move);
       
        //apply actual movement normalized by the change in time scaled to the inputted player speed
        controller.Move(move * Time.deltaTime * playerSpeed);



    }

    public void ResetThismonster()
    {
       monstScript.reset();
    }
}