using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    bool showscroll = false;
    private float speed = 10f;

    public Text goals;
    public Text completed;

    GameObject prompt;
    Vector3 upscroll;
    Vector3 downscroll;

    void Start()
    {
        prompt = GameObject.Find("Prompt");
        downscroll = transform.position;
        upscroll = downscroll;
        upscroll.y = upscroll.y + 150;
    }

    void Update()
    {
        speed = Time.deltaTime * 10 < 2 ? 2 : Time.deltaTime * 10;
        if (Input.GetKeyDown("g")) showscroll = !showscroll;
        if(showscroll)
        {
            transform.position = Vector3.MoveTowards(transform.position, upscroll, speed);
            prompt.SetActive(false);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, downscroll, speed);
            prompt.SetActive(true);
        }
    }
}
