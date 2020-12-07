using UnityEngine.UI;
using UnityEngine;

//Manages the scoring for the game.
public class ScoreManager : MonoBehaviour
{
    Text scoreText; //Score text.
    public int score = 0; //Total score.
    public GoalManager goal; //Goal Manager reference.
    bool scoreGoal = false; //Has the score goal been met?
    bool blowUp = false; //Is the score 'blowing up'?
    int scoreToAdd = 0; //Score to add when blowing up.
    ScoreTracker track; //Score Tracker reference.

    void Start()
    {
        //Get score text and score tracker.
        scoreText = GetComponent<Text>();
        track = GameObject.Find("ScoreKeeper").GetComponent<ScoreTracker>();
    }

    void Update()
    {
        //Set score text.
        scoreText.text = "$" + score;
        //If score meets goal amount, trigger goal.
        if (!scoreGoal && score >= 500)
        {
            scoreGoal = true;
            goal.Complete("damage");
        }
        //If blowing up, increment score and decrement score to add.
        if (blowUp)
        {
            score++;
            scoreToAdd--;
        }
        //Stop blowup if no more score to add.
        if(scoreToAdd <= 0)
        {
            blowUp = false;
        }
        //Update score tracker for high scores.
        track.score = score;
    }

    //Increases the score value
    public void Increase(int value)
    {
        score += value;
    }

    //Sets an amount to increment the score over time for large amounts.
    public void BlowUp(int value)
    {
        blowUp = true;
        scoreToAdd = value;
    }
}
