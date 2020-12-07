using UnityEngine;

//Script for handling wall art goal.
public class WallArt : MonoBehaviour
{
    //Capture start position, triggered state and goal manager.
    private Vector3 start;
    private bool triggered = false;
    public GoalManager gm;

    void Start()
    {
        start = this.transform.position;
    }

    void Update()
    {
        ///If the trigger is false, and the wallart has moved, complete the goal.
        if (!triggered && Vector3.Distance(this.transform.position, start) > 1)
        {
            triggered = true;
            gm.Complete("art");
        }
    }
}
