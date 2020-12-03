using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public GameObject clock;
    public GameObject player;
    public GameObject cam;
    public GameObject cam2;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("IntroComplete"))
        {
            clock.GetComponent<Timer>().enabled = true;
            cam.GetComponent<MouseLook>().enabled = true;
            cam2.GetComponent<MouseLook>().enabled = true;
            player.GetComponent<PlayerMovement>().enabled = true;
            this.gameObject.SetActive(false);
        }
    }
}
