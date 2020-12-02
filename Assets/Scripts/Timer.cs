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
            // StartCoroutine(Fading());
            testEnd();
        }
        else timeText.text = seconds < 10 ? timeText.text = minutes + ":0" + seconds : timeText.text = minutes + ":" + seconds; ;
        if (toggle && seconds % 2 == 1) timeText.fontStyle = FontStyle.Bold;
        else timeText.fontStyle = FontStyle.Normal;
    }

    public void Increase(int time)
    {
        timeRemaining += time;
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => white.color.a == 1);
        anim.SetBool("Fade", false);
        anim.StopPlayback();
        //SceneManager.LoadScene("Menu");
        testEnd();
    }

    void testEnd()
    {
        GameObject cash = GameObject.Find("Cash");
        cash.transform.position = new Vector3(Screen.width/2, Screen.height/10, 0f);
        cash.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        GameObject score = GameObject.Find("Score");
        score.GetComponent<ScoreManager>().Results();
        GameObject player = GameObject.Find("Player");
        player.GetComponent<PlayerMovement>().enabled = false;
        GameObject cam = GameObject.Find("Camera");
        cam.GetComponent<MouseLook>().xRotation = 0f;
        cam.GetComponent<MouseLook>().enabled = false;
        Physics.gravity = new Vector3(0, -1.0F, 0);
        cam.transform.rotation = Quaternion.identity;
        player.transform.position = new Vector3(-1.10789061f, -0.519999981f, -3.75999999f);
        player.transform.rotation = Quaternion.identity;
    }

}
