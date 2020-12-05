using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject defaultCam;
    public GameObject sniffVisionCam;
    public GameObject sniffFood;
    public GameObject sniffFood2;
    public float targetTime = 15.0f;

    bool isSniffFood = false;
    bool isSniffFood2 = false;

    void Start()
    {
        defaultCam.GetComponent<Camera>().enabled = true;
        sniffVisionCam.GetComponent<Camera>().enabled = false;
    }

    void Update()
    {
        if (!sniffFood)
        {
            if (!isSniffFood)
            {
                resetTime();
                isSniffFood = true;
            }
            changeCam();

        }
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

    private void changeCam()
    {
        if (targetTime > 0)
        {
            targetTime -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.E))
            {
                defaultCam.GetComponent<Camera>().enabled = false;
                sniffVisionCam.GetComponent<Camera>().enabled = true;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                defaultCam.GetComponent<Camera>().enabled = true;
                sniffVisionCam.GetComponent<Camera>().enabled = false;
            }
        }
        else
        {
            defaultCam.GetComponent<Camera>().enabled = true;
            sniffVisionCam.GetComponent<Camera>().enabled = false;
        }
    }


    private void resetTime()
    {
        targetTime = 15.0f;
    }
}
