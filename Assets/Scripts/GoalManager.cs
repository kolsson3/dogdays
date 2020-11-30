using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalManager : MonoBehaviour
{
    public int displayCount = 5;
    Goal[] goals;
    string[] tips;
    string goalText = "";
    string completeText;
    Text goalDisplay;
    public GameObject notification;

    void Start()
    {
        tips = new string[]
        {
            "Run to knock stuff over!",
            "Stack boxes to climb!"
        };

        goalDisplay = GetComponent<Text>();
        goals = new Goal[] {
            new Goal("Escape the bedroom", "bedroom"),
            new Goal("Unlock the bathroom", "bathroom"),
            new Goal("Kill some time", "time"),
            new Goal("Climb to new heights", "height"),
            new Goal("Make some noise", "loud"),
            new Goal("Flood the bathroom", "flood"),
            new Goal("Ruin someone's sleep", "pillow"),
            new Goal("Cause $500 in damage", "damage"),
            new Goal("Find the secret safe", "safe_get")
            
        };
        Shuffle(goals);
        Shuffle(tips);
        for(int i = 0; i < displayCount; i++)
        {
            if (goals[i] != null && !goals[i].completed)
            {
                goalText += goals[i].text + "\n";
            }
        }
        goalText += "\nTip:\n" + tips[0];
    }

    void Update()
    {
        if (goalDisplay != null) goalDisplay.text = goalText;
    }

    public void Complete(string id)
    {
        foreach(Goal g in goals)
        {
            if (g.id == id && !g.completed)
            {
                notification.transform.GetChild(1).GetComponent<Text>().text = "Goal Complete! " + g.text;
                notification.GetComponent<Animator>().Play("Notification");
                if (g.id == "safe_get")
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

    //Fisher Yates shuffle for randomizing maze generation.
    public void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
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
