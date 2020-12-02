using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalManager : MonoBehaviour
{
    Goal[] goals;
    string goalText = "";
    Text goalDisplay;

    void Start()
    {
        goalDisplay = GetComponent<Text>();
        goals = new Goal[] {
            new Goal("Escape the Bedroom", "bedroom"),
            new Goal("Unlock the Bathroom", "bathroom"),
            new Goal("Kill some Time", "time"),
            new Goal("Make some noise", "loud"),
            new Goal("Flood the Bathroom", "flood"),
            new Goal("Ruin someone's sleep", "pillow"),
            new Goal("Cause $500 in damage", "damage"),
            new Goal("Find the secret safe", "safe_get")
            
        };
        foreach (Goal g in goals)
        {
            if (g != null && !g.completed)
            {
                goalText += g.text + "\n";
            }
        }
    }

    void Update()
    {
        if (goalDisplay != null) goalDisplay.text = goalText;
    }

    public void Complete(string id)
    {
        foreach(Goal g in goals)
        {
            if (g.id == id)
            {
                if(g.id == "safe_get")
                {
                    g.id = "safe_open";
                    g.text = "Open the safe";
                }
                else
                {
                    g.completed = true;
                }
                
            }
        }
        goalText = "";
        foreach (Goal g in goals)
        {
            if (g != null && !g.completed)
            {
                goalText += g.text + "\n";
            }
        }
    }


    class Goal
    {
        public bool completed = false;
        public string text;
        public string id;

        public Goal(string text, string id) { this.text = text; this.id = id; }
    }
}
