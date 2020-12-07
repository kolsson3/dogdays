using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

//Script for handling menu navigation.
public class Menu : MonoBehaviour
{
    void Start()
    {
        //Lock cursor.
        Cursor.lockState = CursorLockMode.None;
        //If no high score table exists, create it.
        if (!PlayerPrefs.HasKey("highscoreTable"))
        {
            //List<HighscoreEntry> highscoreEntryList = new List<HighscoreEntry>();
            string json = JsonUtility.ToJson(new List<HighscoreEntry>());
            PlayerPrefs.SetString("highscoreTable", json);
            PlayerPrefs.Save();
        }
    }

    //Load a specified scene, used for button clicks.
    public void StartGame(string level)
    {
        SceneManager.LoadScene(level);
    }

    //Function for quitting application.
    public void ExitGame()
    {
        Application.Quit();
    }
}
