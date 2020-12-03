using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    Text timeText;
    public GameObject scrMng;
    public float timeRemaining = 300;

    void Start()
    {
        timeText = GetComponent<Text>();
    }

    void Update()
    {
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        if (timeRemaining > 0) timeRemaining -= Time.deltaTime;
        timeText.text = seconds < 10 ? timeText.text = minutes + ":0" + seconds : timeText.text = minutes + ":" + seconds; ;
        if (timeRemaining <= 0)
        {
            int score = scrMng.GetComponent<ScoreManager>().score;
            //HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = PlayerPrefs.GetString("currName") };

            string jsonString = PlayerPrefs.GetString("highscoreTable");
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

            int index = highscores.highscoreEntryList.FindIndex(player => player.name == PlayerPrefs.GetString("currName"));
            if (index >= 0)
            {
                highscores.highscoreEntryList[index].score = score;
            }
            string json = JsonUtility.ToJson(highscores);
            PlayerPrefs.SetString("highscoreTable", json);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Menu");
        }
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }
}
