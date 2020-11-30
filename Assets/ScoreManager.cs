using UnityEngine.UI;
using UnityEngine;
using System.Collections;


public class ScoreManager : MonoBehaviour
{
    Text scoreText;
    public int score = 0;
    
    public GoalManager goal;
    bool blowUp = false;
    bool scoreGoal = false;
    int scoreToAdd = 0;

    ArrayList destruction;

    void Start()
    {
        scoreText = GetComponent<Text>();
        destruction = new ArrayList();
    }

    void Update()
    {
        scoreText.text = "$" + score;
        if (!scoreGoal && score >= 500)
        {
            scoreGoal = true;
            goal.Complete("damage");
        }
        if (blowUp)
        {
            score++;
            scoreToAdd--;
        }
        if(scoreToAdd <= 0)
        {
            blowUp = false;
        }
    }

    public void Increase(int value, GameObject obj)
    {
        score += value;
        destruction.Add(obj);
    }

    public void Increase(int value)
    {
        score += value;
    }

    public void BlowUp(int value)
    {
        blowUp = true;
        scoreToAdd = value;
    }

    public void Results()
    {
        foreach(GameObject o in destruction)
        {
            Debug.Log(o.name);
            Instantiate(o, new Vector3(0f, 0f, 0f), Quaternion.identity);
        }
    }
}

