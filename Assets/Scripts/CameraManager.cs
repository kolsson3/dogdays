using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manager to swap cameras for sniff vision.
public class CameraManager : MonoBehaviour
{
    public GameObject defaultCam; //Non-sniff cam.
    public GameObject sniffVisionCam; //Sniff cam.
    public GameObject sniffFood; //Tracks food object.
    public GameObject sniffFood2; //Tracks food object.
    public float targetTime = 15.0f; //Time that sniff is active.

    bool isSniffFood = false; //Is sniffing from first food item.
    bool isSniffFood2 = false; //Is sniffing from second food item.

    void Start()
    {
        //Enabel default camera and disable sniff camera.
        defaultCam.GetComponent<Camera>().enabled = true;
        sniffVisionCam.GetComponent<Camera>().enabled = false;
    }

    void Update()
    {
        //If food has been destroyed/eaten
        if (!sniffFood)
        {
            //If not already sniffing, do so.
            if (!isSniffFood)
            {
                //Reset timer.
                resetTime();
                isSniffFood = true;
            }
            //Change camera.
            changeCam();
        }
        //Repeat above for other food object.
        if (!sniffFood2)
        {
            if (!isSniffFood2)
            {
                resetTime();
                isSniffFood2 = true;
            }
            changeCam();
        }
    }

    //Change camera if sniffing.
    private void changeCam()
    {
        //If time remaining on sniff...
        if (targetTime > 0)
        {
            //Decrement timer.
            targetTime -= Time.deltaTime;
            //On sniff input, change camera.
            if (Input.GetKeyDown(KeyCode.E))
            {
                defaultCam.GetComponent<Camera>().enabled = false;
                sniffVisionCam.GetComponent<Camera>().enabled = true;
            }
            //Change back on key up.
            if (Input.GetKeyUp(KeyCode.E))
            {
                defaultCam.GetComponent<Camera>().enabled = true;
                sniffVisionCam.GetComponent<Camera>().enabled = false;
            }
        }
        //If timer runs out, force change back to default camera.
        else
        {
            defaultCam.GetComponent<Camera>().enabled = true;
            sniffVisionCam.GetComponent<Camera>().enabled = false;
        }
    }

    //Resets sniff timer.
    private void resetTime()
    {
        targetTime = 15.0f;
    }
}
