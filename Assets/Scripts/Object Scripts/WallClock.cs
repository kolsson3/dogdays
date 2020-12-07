using UnityEngine;

//Script to handle the goal assiciated with the wall clocks.
public class WallClock : MonoBehaviour
{
    private Vector3 start;
    private bool triggered = false;
    public Timer timer;
    public GoalManager gm;

    void Start()
    {   
        //Track start position.
        start = this.transform.position;
    }

    void Update()
    {
        //If goal not already triggered, and clock has moved from start, trigger goal and increase timer.
        if(!triggered && Vector3.Distance(this.transform.position, start) > 1)
        {
            triggered = true;
            timer.Increase(30);
            gm.Complete("time");
        }
    }
}
