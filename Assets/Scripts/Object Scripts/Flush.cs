using UnityEngine;

//Script for handling the toilet flush
public class Flush : MonoBehaviour
{
    //Grab threshold for activating handle.
    public float grabThreshold = 0.75f;
    //Track the object clogging the toilet.
    GameObject clog;
    bool clogged = false;
    //Score value for flooding.
    public int value = 100;
    //Objects for scores, goals, player location, and handle.
    public ScoreManager sm;
    public GoalManager goal;
    public Transform destination;
    private GameObject handle;
    //Particle system to play when the toilet is flooding
    public ParticleSystem flood;
    
    void Start()
    {
        //Grab the handle object
        handle = gameObject.transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        //If an object other than the player enters the trigger collider, track it.
        if (other.gameObject.name != "Player") 
        {
            clogged = true;
            clog = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //If the clogging object leaves the collider, update accordingly.
        if (clog != null && other.gameObject.name == clog.name) clog = null;
    }

    void OnMouseDown()
    {
        Vector3 Dest = destination.position;
        float distance = Vector3.Distance(Dest, handle.transform.position);
        if (distance <= grabThreshold)
        {
            //If player is close enough to the handle, animate it.
            handle.GetComponent<Animator>().Play("Toilet");
            //If the toulet is clogged, complete goal, increase score, and activate particles.
            if (clogged)
            {
                sm.Increase(value);
                flood.Play();
                goal.Complete("flood");
            }
        }
    }
}
