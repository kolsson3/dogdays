using UnityEngine;

//Script for controlling shakeable objects
//Wasn't able to figure out a 'shake' so currently simulating via right mouse click and only applies to pillows on main bed.
public class Shakeable : MonoBehaviour
{
    //Values for grabbing, particle system, number of shakes on the object, and value to increase when shaking.
    public float grabThreshold = 0.1f;
    public ParticleSystem ps;
    public bool facing = false;
    public int shakes = 5;
    public int value = 5;
    //Game objects for player, goal manager, and score manager.
    public ScoreManager sm;
    public GoalManager goal;
    public GameObject player;

    //Get player object at start.
    void Start()
    {
        player = GameObject.Find("Target");
    }

    void Update()
    {
        //Player distance check. If within distance and 'shakes' remaining, proceed.
        float distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= grabThreshold && facing && Input.GetMouseButtonDown(1) && shakes > 0) {
            //Clear the particle system and restart it.
            ps.Stop();
            ps.Clear();
            ps.Play();
            //Decrement shakes, score the value, decrease object size.
            shakes--;
            sm.Increase(value);
            transform.localScale -= new Vector3(0f, 0.15f, 0f);
        }
        //Complete pillow goal if no shakes remaining.
        if (shakes == 0) goal.Complete("pillow");
    }

    //Check if player is facing object and is close enough
    void OnMouseEnter()
    {
        float distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= grabThreshold) facing = true;
    }

    //Check if player is no longer facing object
    void OnMouseExit()
    {
        facing = false;
    }
}
