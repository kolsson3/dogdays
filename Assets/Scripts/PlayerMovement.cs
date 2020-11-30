using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public GoalManager gm;
    public float speed = 15f;
    private float vSpeed = 0f; // current vertical velocity
    public float jumpSpeed = 2.5f;
    float gravity = 9.8f;
    bool run = false;


    //public GameObject barkAbility;
    // public GameObject runAbility;
    //public GameObject sniffAbility;



    //public AudioSource ASWalk;


    public AudioSource sniff;
    public AudioClip bark1;
    public AudioClip bark2;
    public AudioClip bark3;
    public AudioSource source;

    private int barkCount = 0;
    bool barked = false;


    void Update()
    {
        if (Input.GetButtonDown("Bark")) Bark();
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
        //if (controller.velocity.magnitude == 0f && ASWalk.isPlaying == true)
        //{
        //    ASWalk.Stop();
        //}
        //if (controller.isGrounded == true && controller.velocity.magnitude > 0.01f && ASWalk.isPlaying == false)
        //{
        //    ASWalk.volume = Random.Range(0.2f, 0.5f);
        //    ASWalk.pitch = Random.Range(0.8f, 1.1f);
        //    ASWalk.Play();

        //}

        // controllers for add-ons



        // code for sniffing
        //if (!sniffAbility)
        //{
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        ASSniff.Play();
        //        ASSniff.loop = true;
        //    }
        //    if (Input.GetKeyUp(KeyCode.E))
        //    {
        //        ASSniff.Stop();
        //        ASSniff.loop = false;

        //    }
        //}
    }

    public void Bark()
    {
        int bark = Random.Range(0, 100);
        if(bark == 0) source.PlayOneShot(bark3, 1.0f);
        else if (bark < 40) source.PlayOneShot(bark2, 1.0f);
        else source.PlayOneShot(bark1, 1.0f);

        if (barkCount < 10 && !barked) barkCount++;
        else
        {
            gm.Complete("loud");
            barked = true;
        }
    }
}
