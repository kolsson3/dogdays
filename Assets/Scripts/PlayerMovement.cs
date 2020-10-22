using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 15f;
    private float vSpeed = 0f; // current vertical velocity
    public float jumpSpeed = 2.5f;
    float gravity = 9.8f;
    bool run = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) run = true;
        if (Input.GetKeyUp(KeyCode.LeftShift)) run = false;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (run)
        {
            x *= 2;
            z *= 2;
        }
        Vector3 move = transform.right * x + transform.forward * z;


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
        move.y = vSpeed; // include vertical speed in vel
                        // convert vel to displacement and Move the character:
        controller.Move(move * speed * Time.deltaTime);
    }
}
