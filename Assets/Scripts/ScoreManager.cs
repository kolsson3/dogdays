using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    Text scoreText;
    public int score = 0;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = "$" + score;
    }

    public void Increase(int value)
    {
        score += value;
    }
}
