using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallArt : MonoBehaviour
{
    private Vector3 start;
    private bool triggered = false;
    public GoalManager gm;

    void Start()
    {
        start = this.transform.position;
    }

    void Update()
    {
        if (!triggered && Vector3.Distance(this.transform.position, start) > 1)
        {
            triggered = true;
            gm.Complete("art");
        }
    }
}
