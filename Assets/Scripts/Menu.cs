using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<AudioSource>().Play();
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGame(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
