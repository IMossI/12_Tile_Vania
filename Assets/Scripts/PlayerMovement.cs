﻿using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] // note new attribute
    public bool isOnLadder = false; 
    
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f; // todo consider Vector2
    [SerializeField] float climbSpeed = 5f;

    Rigidbody2D myRigidBody;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessHorizontal();
        ProcessJumps();
        FaceCorrectDirection();
        ClimbWhenOnLadder();
    }

    private void ClimbWhenOnLadder()
    {
        if (!isOnLadder) { return; }

        float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 playerVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * climbSpeed);  // todo maybe force x to 0?
        myRigidBody.velocity = playerVelocity;
    }

    private void FaceCorrectDirection()
    {
        bool playerIsNotMoving = Mathf.Abs(myRigidBody.velocity.x) < Mathf.Epsilon;
        if (playerIsNotMoving)
        {
            // don't change player direction
        }
        else
        {
            // reverse x scale to flip player horizontally
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);  
        }
    }

    private void ProcessHorizontal()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // value between -1 and +1

        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
    }

    private void ProcessJumps()
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump")) // Down so once per press
        {
            Vector2 jumpVelocityAdded = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityAdded;
        }
    }
}