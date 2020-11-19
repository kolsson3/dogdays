using UnityEngine.UI;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    Text scoreText;
    public int score = 0;
    
    public GoalManager goal;
    bool blowUp = false;
    int scoreToAdd = 0;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = "$" + score;
        if (score >= 500) goal.Complete("damage");
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

    public void Increase(int value)
    {
        score += value;
    }

    public void BlowUp(int value)
    {
        blowUp = true;
        scoreToAdd = value;
    }
}

