using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    Text timeText;
    public Animator anim;
    public Image white;
    public float timeRemaining = 300;
    private bool toggle = false;
    private bool ended = false;
    public AudioSource source;
    public AudioClip tires;
    public AudioClip door;
    public GameObject scrMng;

    void Start()
    {
        timeText = GetComponent<Text>();
    }

    void Update()
    {
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        if (timeRemaining > 0) timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 30 && !toggle) toggle = true;
        if (timeRemaining <= 0 && !ended)
        {
            ended = true;
            timeRemaining = 0;
            StartCoroutine(EndSound());
            StartCoroutine(Fading());
        }
        else timeText.text = seconds < 10 ? timeText.text = minutes + ":0" + seconds : timeText.text = minutes + ":" + seconds; ;
        if (toggle && seconds % 2 == 1) timeText.fontStyle = FontStyle.Bold;
        else timeText.fontStyle = FontStyle.Normal;
    }

    public void Increase(int time)
    {
        timeRemaining += time;
    }

    public void SetFinalScore()
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
    }

    IEnumerator EndSound()
    {
        source.PlayOneShot(tires, 1.0f);
        yield return new WaitUntil(() => !source.isPlaying);
        source.PlayOneShot(door, 1.0f);
        yield return new WaitUntil(() => !source.isPlaying);

    }

    IEnumerator Fading()
    {
        yield return new WaitUntil(() => !source.isPlaying);
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => white.color.a == 1);
        anim.SetBool("Fade", false);
        anim.StopPlayback();
        SetFinalScore();
        SceneManager.LoadScene("Menu");
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
