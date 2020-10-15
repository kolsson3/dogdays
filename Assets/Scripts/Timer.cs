using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject TimerDisplay;
    public int TimeLeft = 210;  // initial timer, Only works timer less than 240 seconds for now.
    public bool CountDown = false;

    void Start()
    {
        TimerDisplay.GetComponent<Text>().text = "START!";
    }

    void Update()
    {
        if(CountDown == false && TimeLeft > 0)      // CountDown ends when the time left reaches 0 second.
        {
            StartCoroutine(TimerTake());
        }
    }
    IEnumerator TimerTake()
    {
        CountDown = true;
        yield return new WaitForSeconds(1);
        TimeLeft -= 1;
        if(TimeLeft >= 180)
        {
            if(TimeLeft%60 < 10){
                TimerDisplay.GetComponent<Text>().text = "03:0" + (TimeLeft%60);
            }
            else{
                TimerDisplay.GetComponent<Text>().text = "03:" + (TimeLeft%60);
            }
        }
        else if (TimeLeft <= 180 && TimeLeft >= 120) {
            if(TimeLeft%60 < 10){
                TimerDisplay.GetComponent<Text>().text = "02:0" + (TimeLeft%60);
            }
            else{
                TimerDisplay.GetComponent<Text>().text = "02:" + (TimeLeft%60);
            }
        }
        else if (TimeLeft <= 120 && TimeLeft >= 60) {
            if(TimeLeft%60 < 10){
                TimerDisplay.GetComponent<Text>().text = "01:0" + (TimeLeft%60);
            }
            else{
                TimerDisplay.GetComponent<Text>().text = "01:" + (TimeLeft%60);
            }
        }
        else if (TimeLeft <= 60 && TimeLeft >=10) {
            TimerDisplay.GetComponent<Text>().text = "00:" + TimeLeft;
        }
        else if (TimeLeft < 10) {
            TimerDisplay.GetComponent<Text>().text = "00:0" + TimeLeft;
        }
        else
        {
            TimerDisplay.GetComponent<Text>().text = "00:" + TimeLeft;
        }
        CountDown = false;
    }
}

/*
        It is pretty basic if-else statement for now, but I think it is good enough for our alpha build.
        Once we implement main menu and game over mechanics, I will update the timer so that it countsdown in real time.
        
        (self note: Maybe implement text countdown in real time and possibly timer bar that decreses.)

        (TODO: Once the timer reaches 0:
            -popup game over screen that shows the progress? 
            -After we implement some sort of scoring mechanic, display the score.)
        
*/
