using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

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
        SceneManager.LoadScene("Menu");
    }
}
