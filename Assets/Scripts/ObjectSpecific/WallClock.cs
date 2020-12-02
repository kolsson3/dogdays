using UnityEngine;

public class WallClock : MonoBehaviour
{
    private Vector3 start;
    private bool triggered = false;
    public Timer timer;
    public GoalManager gm;

    void Start()
    {   
        start = this.transform.position;
    }

    void Update()
    {
        Debug.Log(Vector3.Distance(this.transform.position, start));
        if(!triggered && Vector3.Distance(this.transform.position, start) > 1)
        {
            triggered = true;
            timer.Increase(30);
            gm.Complete("time");
        }
    }
}
