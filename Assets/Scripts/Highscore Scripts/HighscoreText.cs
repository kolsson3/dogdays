using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

//Script for grabbing high score text and submitting it to player prefs.
public class HighscoreText : MonoBehaviour
{
    Text scoreText;
    int score;
    public GameObject inpField;

    void Start()
    {
        //Get and display score from the player's finished run.
        scoreText = GetComponent<Text>();
        GameObject scoreKeeper = GameObject.Find("ScoreKeeper");
        if (scoreKeeper)
        {
            score = scoreKeeper.GetComponent<ScoreTracker>().score;
            scoreText.text = "Your high score is: " + score;
        }
    }

    //Submit high score value.
    public void Submit()
    {
        AddPlayer();
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //Find player, if they have a score, replace it if the new one is higher.
        int index = highscores.highscoreEntryList.FindIndex(player => player.name == PlayerPrefs.GetString("currName"));
        if (index >= 0)
        {
            int oldScore = highscores.highscoreEntryList[index].score;
            if(score > oldScore) highscores.highscoreEntryList[index].score = score;
        }
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();

        //Load high score scene.
        SceneManager.LoadScene("Highscore");
    }

    
    //Add a player to the high score list.
    public void AddPlayer()
    {
        //Get name from input.
        string name = inpField.GetComponent<Text>().text.Trim();
        if (name != "")
        {
            PlayerPrefs.SetString("currName", name.Trim());
            PlayerPrefs.Save();

            HighscoreEntry highscoreEntry = new HighscoreEntry(score, name.Trim());

            string jsonString = PlayerPrefs.GetString("highscoreTable");
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

            //Get index of player in high score list.
            int index = highscores.highscoreEntryList.FindIndex(player => player.name == name.Trim());
            if (index < 0)
            {
                highscores.highscoreEntryList.Add(highscoreEntry);
            }

            string json = JsonUtility.ToJson(highscores);
            PlayerPrefs.SetString("highscoreTable", json);
            PlayerPrefs.Save();
        }
    }

    //Container class for high score list.
    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }
}
