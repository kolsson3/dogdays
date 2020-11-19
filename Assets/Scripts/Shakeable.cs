using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shakeable : MonoBehaviour
{
    public float grabThreshold = 0.1f;
    public ParticleSystem ps;
    public bool facing = false;
    public int shakes = 5;
    public ScoreManager sm;
    public int value = 5;
    public GoalManager goal;

    void Update()
    {
        Vector3 Dest = GameObject.Find("Target").transform.position;
        float distance = Vector3.Distance(Dest, this.transform.position);
        if (distance <= grabThreshold && facing && Input.GetMouseButtonDown(1) && shakes > 0) {
            ps.Stop();
            ps.Clear();
            ps.Play();
            shakes--;
            sm.Increase(value);
            transform.localScale -= new Vector3(0f, 0.15f, 0f);
        }
        if (shakes == 0) goal.Complete("pillow");
    }


    void OnMouseEnter()
    {
        Vector3 Dest = GameObject.Find("Target").transform.position;
        float distance = Vector3.Distance(Dest, this.transform.position);
        if (distance <= grabThreshold) facing = true;
    }

    void OnMouseExit()
    {
        facing = false;
    }
}
