using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed = 10f; // units per seconds
float turnSpeed = 90f; // degrees per second
float jumpSpeed = 8f;
float gravity = 9.8f;
private float vSpeed = 0f; // current vertical velocity
    public CharacterController controller;
    private bool run = false;

void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            run = true;
        }if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            run = false;
        }
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
        Vector3 vel = transform.forward * Input.GetAxis("Vertical") * speed;
        if (run) vel = vel * 2;
        if (controller.isGrounded)
        {
            vSpeed = 0; // grounded character has vSpeed = 0...
            if (Input.GetKeyDown("space"))
            { // unless it jumps:
                vSpeed = jumpSpeed;
            }
        }
        // apply gravity acceleration to vertical speed:
        vSpeed -= gravity * Time.deltaTime;
        vel.y = vSpeed; // include vertical speed in vel
                        // convert vel to displacement and Move the character:
        controller.Move(vel * Time.deltaTime);
        
    }
}
