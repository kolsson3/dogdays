using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Menu : MonoBehaviour
{

    List<string> levels = new List<string>(); 

    void Start()
    {
        this.GetComponent<AudioSource>().Play();
        Cursor.lockState = CursorLockMode.None;
        // Reset the highsores table to empty
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.Save();
        levels.Add("Alpha");
        levels.Add("Nature");
        if (!PlayerPrefs.HasKey("highscoreTable"))
        {
            List<HighscoreEntry> highscoreEntryList = new List<HighscoreEntry>();
            string json = JsonUtility.ToJson(highscoreEntryList);
            PlayerPrefs.SetString("highscoreTable", json);
            PlayerPrefs.Save();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(levels[Random.Range(0,2)]);
    }

    public void GoToHighScore()
    {
        SceneManager.LoadScene("Highscore");
    }

    public void GoToEnterName()
    {
        SceneManager.LoadScene("EnterName");
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
