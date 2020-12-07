using UnityEngine;

//Plays the game's intro animation
public class Intro : MonoBehaviour
{
    //Objects for the clock, player, and cameras
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
        //Once the animation is complete, activate the clock, cameras and player, deactivate this object.
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
