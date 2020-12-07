using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniffAbility : MonoBehaviour
{
    public Material seeThru; //Transparent material.
    public AudioSource sniffSource; //Sniff source.
    public AudioClip sniffSFX; //Sniff sound.
    public Material keyMat; //Default material for bathroom key
    public Material keyMat2; //Default material for bedroom key
    public Material code1; //Default material for sticky note 1.
    public Material code2; //Default material for sticky note 2.
    public Material code3; //Default material for sticky note 3.
    public GameObject sniffFood; //Upstairs food.
    public GameObject sniffFood2; //Downstairs food.
    public float targetTime = 15.0f; //Sniff timer.
    private GameObject[] keys; //Key objects.
    bool isSniffFood = false; //Is sniffing from upstairs food.
    bool isSniffFood2 = false; //Is sniffing from downstairs food.

    //Find keys on start.
    void Start()
    {
        keys = GameObject.FindGameObjectsWithTag("Key");
    }

    void Update()
    {
        //If first food destroyed/eaten...
        if (!sniffFood)
        {
            //If not sniffing already, reset timer and start sniff.
            if (!isSniffFood)
            {
                resetTime();
                isSniffFood = true;
            }
            sniff();
        }
        //Repeat above for second food object.
        if (!sniffFood2)
        {
            if (!isSniffFood2)
            {
                resetTime();
                isSniffFood2 = true;
            }
            sniff();
        }
    }

    //Reset timer.
    private void resetTime()
    {
        targetTime = 15.0f;
    }

    private void sniff()
    {
        //If time remaining...
        if (targetTime > 0.0f)
        {
            //Decrement timer.
            targetTime -= Time.deltaTime;
            //On key down for sniff...
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Enable materials and particles for sniffable objects.
                for (int i = 0; i < keys.Length; i++)
                {
                    keys[i].GetComponent<Renderer>().material = seeThru;
                    keys[i].GetComponent<ParticleSystem>().Play();
                    sniffSource.PlayOneShot(sniffSFX, 1.0f);
                }
            }
            //On key up for sniff...
            if (Input.GetKeyUp(KeyCode.E))
            {
                //Reset materials and stop particle systems.
                for (int i = 0; i < keys.Length; i++)
                {
                    if (keys[i].name == "Bedroom_Key") keys[i].GetComponent<Renderer>().material = keyMat2;
                    else if (keys[i].name == "Bathroom_Key") keys[i].GetComponent<Renderer>().material = keyMat;
                    else if (keys[i].name == "Note1") keys[i].GetComponent<Renderer>().material = code1;
                    else if (keys[i].name == "Note2") keys[i].GetComponent<Renderer>().material = code2;
                    else if (keys[i].name == "Note3") keys[i].GetComponent<Renderer>().material = code3;
                    keys[i].GetComponent<ParticleSystem>().Stop();
                }
            }
        }
        else
        {
            //Reset materials and particle systems if timer runs out.
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i].name == "Bedroom_Key") keys[i].GetComponent<Renderer>().material = keyMat2;
                else if (keys[i].name == "Bathroom_Key") keys[i].GetComponent<Renderer>().material = keyMat;
                else if (keys[i].name == "Note1") keys[i].GetComponent<Renderer>().material = code1;
                else if (keys[i].name == "Note2") keys[i].GetComponent<Renderer>().material = code2;
                else if (keys[i].name == "Note3") keys[i].GetComponent<Renderer>().material = code3;
                keys[i].GetComponent<ParticleSystem>().Stop();
            }
        }
    }
}
