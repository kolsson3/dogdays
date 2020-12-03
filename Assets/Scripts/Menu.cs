using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Menu : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<AudioSource>().Play();
        Cursor.lockState = CursorLockMode.None;
        if (!PlayerPrefs.HasKey("highscoreTable"))
        {
            List<HighscoreEntry> highscoreEntryList = new List<HighscoreEntry>();
            string json = JsonUtility.ToJson(highscoreEntryList);
            PlayerPrefs.SetString("highscoreTable", json);
            PlayerPrefs.Save();
        }
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.Save();
    }

    public void StartGame(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void ExitGame()
    {
        Application.Quit();
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
