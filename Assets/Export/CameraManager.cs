using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject defaultCam;
    public GameObject sniffVisionCam;
    public GameObject sniffFood;
    public float targetTime = 5.0f;

    void Start()
    {
        defaultCam.GetComponent<Camera>().enabled = true;
        sniffVisionCam.GetComponent<Camera>().enabled = false;
    }

    void Update()
    {
        if(!sniffFood && targetTime > 0)
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
        if (Input.GetKeyUp(KeyCode.E))
        {
            defaultCam.GetComponent<Camera>().enabled = true;
            sniffVisionCam.GetComponent<Camera>().enabled = false;
        }
    }
}
