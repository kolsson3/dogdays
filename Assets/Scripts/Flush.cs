using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flush : MonoBehaviour
{
    public Transform destination;
    public float grabThreshold = 0.5f;
    bool clogged = false;
    public ParticleSystem flood;
    GameObject clog;
    public ScoreManager sm;
    public int value = 100;
    public GoalManager goal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player") 
        {
            clogged = true;
            clog = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (clog != null && other.gameObject.name == clog.name)
        {
            clog = null;
        }
    }

    void OnMouseDown()
    {
        Vector3 Dest = GameObject.Find("Target").transform.position;
        float distance = Vector3.Distance(Dest, this.transform.position);
        if (distance <= grabThreshold) Clog();
    }

    public void Clog()
    {
        if(clogged)
        {
            sm.Increase(value);
            flood.Play();
            goal.Complete("flood");
        }
    }
}
