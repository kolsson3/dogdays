using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Manager for game goals.
public class GoalManager : MonoBehaviour
{
    public int displayCount = 5; //Number of goals to display.
    Goal[] goals; //All goals.
    Goal[] displayGoals; //Displayed goals.
    string[] tips; //Game tips.
    string goalText = ""; //Text for goals.
    string completeText; //Text when goal is completed.
    Text goalDisplay; //Text object to show goal text.
    public GameObject notification; //Game object showing complete notification.

    void Start()
    {
        //Enter game tips.
        tips = new string[]
        {
            "Run to knock stuff over!",
            "Stack boxes to climb!"
        };

        //Create all goals.
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
            new Goal("Find the secret safe", "safe_get"),
            new Goal("Appreciate art", "art")
        };

        //Shuffle goal and tip arrays.
        Shuffle(goals);
        Shuffle(tips);

        //Create displayed goals and grab the initial set from shuffled goal list.
        displayGoals = new Goal[displayCount];
        for(int i = 0; i < displayCount; i++)
        {
            if (goals[i] != null && !goals[i].completed)
            {
                //For each displayed goal, add it to goal text.
                displayGoals[i] = goals[i];
                goalText += goals[i].text + "\n";
            }
        }
        //Add tip to goal text.
        goalText += "\nTip:\n" + tips[0];
    }

    //Update goal text as it changes.
    void Update()
    {
        if (goalDisplay != null) goalDisplay.text = goalText;
    }

    //Function called by other scripts to complete goals.
    public void Complete(string id)
    {
        //Iterate over displayed goals.
        foreach(Goal g in displayGoals)
        {
            //If ID matches and not completed...
            if (g.id == id && !g.completed)
            {
                //Notify player of completion.
                notification.transform.GetChild(1).GetComponent<Text>().text = "Goal Complete! " + g.text;
                notification.GetComponent<Animator>().Play("Notification");
                //Safe find goal is updated to safe open goal rather than being removed.
                if (g.id == "safe_get")
                {
                    g.id = "safe_open";
                    g.text = "Open the safe";
                }
                //Completes goal if not a special case.
                else g.completed = true;
            }
        }
        //Iterate over goals and generate new text to remove completed goal.
        goalText = "";
        foreach (Goal g in displayGoals)
        {
            if (g != null && !g.completed) goalText += g.text + "\n";
        }
    }

    //Fisher Yates shuffle for randomizing lists generation.
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

    //Goal class for containing goal information.
    class Goal
    {
        public bool completed = false;
        public string text;
        public string id;

        public Goal(string text, string id) { this.text = text; this.id = id; }
    }
}
