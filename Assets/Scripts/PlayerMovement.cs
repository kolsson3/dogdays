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

    bool canBark = false;

    public AudioSource ASBark;
    public AudioSource ASSniff;
    public AudioSource ASWalk;

    //void Start()
    //{
    //    ASBark = gameObject.AddComponent<AudioSource>();
    //    ASSniff = gameObject.AddComponent<AudioSource>();
    //    ASWalk = gameObject.AddComponent<AudioSource>();
    //}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            run = true;
            this.GetComponent<CapsuleCollider>().enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            run = false;
            this.GetComponent<CapsuleCollider>().enabled = false;
        }
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


        //sound for 
        if (controller.velocity.magnitude == 0f && ASWalk.isPlaying == true)
        {
            ASWalk.Stop();
        }
        if (controller.isGrounded == true && controller.velocity.magnitude > 0.01f && ASWalk.isPlaying == false)
        {
            ASWalk.volume = Random.Range(0.8f, 1);
            ASWalk.pitch = Random.Range(0.8f, 1.1f);
            ASWalk.Play();

        }

        // controllers for add-ons

        // sound for barking
        if (canBark == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ASBark.Play();
            }
        }

        // sound for sniffing
        if (Input.GetKeyDown(KeyCode.E))
        {
            ASSniff.Play();
        }
    }
}
