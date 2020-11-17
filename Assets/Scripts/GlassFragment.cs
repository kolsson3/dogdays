﻿using UnityEngine;

public class GlassFragment : MonoBehaviour
{
    public ScoreManager sm;
    public int value = 5;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" || other.transform.parent.gameObject.name == "Target")
        {
            GetComponent<Collider>().isTrigger = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            sm.Increase(value);
        }
    }   
}
