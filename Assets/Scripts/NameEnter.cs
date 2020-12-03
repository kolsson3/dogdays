using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameEnter : MonoBehaviour
{
    public GameObject inpField;

    public void AddPlayer()
    {
        string name = inpField.GetComponent<Text>().text.Trim();
        if (name != "")
        {
            PlayerPrefs.SetString("currName", name.Trim());
            PlayerPrefs.Save();

            HighscoreEntry highscoreEntry = new HighscoreEntry { score = 0, name = name.Trim() };

            string jsonString = PlayerPrefs.GetString("highscoreTable");
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

            int index = highscores.highscoreEntryList.FindIndex(player => player.name == name.Trim());
            if (index < 0)
            {
                highscores.highscoreEntryList.Add(highscoreEntry);
            }

            string json = JsonUtility.ToJson(highscores);
            PlayerPrefs.SetString("highscoreTable", json);
            PlayerPrefs.Save();
            SceneManager.LoadScene("NamRelease");
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
