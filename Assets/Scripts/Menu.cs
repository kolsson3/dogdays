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
        levels.Add("Alpha");
        levels.Add("Nature");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(levels[Random.Range(0,2)]);
    }

    public void GoToHighScore()
    {
        SceneManager.LoadScene("Highscore");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
