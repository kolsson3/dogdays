using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

//Class for handling the Timer and triggering end game state.
public class Timer : MonoBehaviour
{
    Text timeText; //Timer text.
    public Animator anim; //Animator for end state fade.
    public Image white; //Image to fade in over the UI.
    public float timeRemaining = 300; //Start time.
    private bool toggle = false; //Toggle for 30 seconds remaining.
    private bool ended = false; //Checks if game is ended.
    public AudioSource source; //Audio source for end game sounds.
    public AudioClip tires; //Tire screech.
    public AudioClip door; //Door slams open.

    void Start()
    {
        //Grab the timer text on start.
        timeText = GetComponent<Text>();
    }

    void Update()
    {
        //Determine minutes and seconds based on time remaining.
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        //Decrement timer.
        if (timeRemaining > 0) timeRemaining -= Time.deltaTime;
        //If less than 30 seconds, switch toggle.
        if (timeRemaining <= 30 && !toggle) toggle = true;
        //If out of time, end the game.
        if (timeRemaining <= 0 && !ended)
        {
            ended = true;
            //Manually set time to avoid display errors.
            timeRemaining = 0;
            //Start end game coroutines for animation and sound.
            StartCoroutine(EndSound());
            StartCoroutine(Fading());
        }
        //If not ended, modify timer text based on remaining time. Add a leading zero if seconds are less than 10.
        else timeText.text = seconds < 10 ? timeText.text = minutes + ":0" + seconds : timeText.text = minutes + ":" + seconds;
        //If toggle is true and seconds is an odd number, set to bold.
        if (toggle && seconds % 2 == 1) timeText.fontStyle = FontStyle.Bold;
        //Else timer is not bold.
        else timeText.fontStyle = FontStyle.Normal;
    }

    //Increase function for any actions that add time.
    public void Increase(int time)
    {
        timeRemaining += time;
    }

    //Coroutine to play the end game sounds one after the other.
    IEnumerator EndSound()
    {
        source.PlayOneShot(tires, 1.0f);
        yield return new WaitUntil(() => !source.isPlaying);
        source.PlayOneShot(door, 1.0f);
    }

    //Coroutine to play the fading animation
    IEnumerator Fading()
    {
        //Don't play until sounds are ove.
        yield return new WaitUntil(() => !source.isPlaying);
        anim.SetBool("Fade", true);
        //Wait until fade to white is complete.
        yield return new WaitUntil(() => white.color.a == 1);
        anim.SetBool("Fade", false);
        anim.StopPlayback();
        //Transition to high score enter screen.
        SceneManager.LoadScene("EnterName");
    }
}
