using UnityEngine;
using UnityEngine.UI;

//Handler for the goals scroll UI element.
public class Scroll : MonoBehaviour
{
    //Is scroll shown
    bool showscroll = false;
    //Speed of scroll moving
    private float speed = 10f;
    //Prompt text when goals are closed.
    GameObject prompt;
    //Target vectors for scroll hidden and shown
    Vector3 upscroll;
    Vector3 downscroll;

    void Start()
    {
        //Grab the prompt, mark downscroll as current position and set upscroll equal to half screen height.
        prompt = GameObject.Find("Prompt");
        downscroll = transform.position;
        upscroll = downscroll;
        upscroll.y = upscroll.y + (Screen.height/2);
    }

    void Update()
    {
        //Calculate speed based on deltaTime, minimum of 2.
        speed = Time.deltaTime * 10 < 2 ? 2 : Time.deltaTime * 10;
        //Toggle scroll with player input
        if (Input.GetKeyDown("g")) showscroll = !showscroll;
        //Depending on scroll status, move towards up or down position. Activate/Deactivate prompt accordingly.
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
