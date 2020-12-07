using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for triggering the goal for players reaching the top of the bookshelf
public class Bookshelf : MonoBehaviour
{
    public GoalManager gm;

    //Checks the trigger box collider on top of the shelf.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            gm.Complete("height");
        }
    }
}
