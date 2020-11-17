using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    Text timeText;
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
        if (timeRemaining <= 0) SceneManager.LoadScene("Menu");
    }
}
