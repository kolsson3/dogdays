using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniffAbility : MonoBehaviour
{

    public Material seeThru;
    public AudioSource sniffSFX;
    public Material keyMat;
    public Material keyMat2;
    public Material code1;
    public Material code2;
    public Material code3;
    public GameObject sniffFood;
    public GameObject sniffFood2;
    public float targetTime = 15.0f;


    private GameObject[] keys;
    bool isSniffFood = false;
    bool isSniffFood2 = false;

    void Start()
    {
        keys = GameObject.FindGameObjectsWithTag("Key");
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
            sniff();
            
        }
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
    private void resetTime()
    {
        targetTime = 15.0f;
    }

    private void sniff()
    {
        if (targetTime > 0.0f)
        {
            targetTime -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.E))
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    keys[i].GetComponent<Renderer>().material = seeThru;
                    keys[i].GetComponent<ParticleSystem>().Play();
                    sniffSFX.Play();
                }
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    if (keys[i].name == "Bedroom_Key")
                    {
                        keys[i].GetComponent<Renderer>().material = keyMat2;
                    }
                    else if (keys[i].name == "Bathroom_Key")
                    {
                        keys[i].GetComponent<Renderer>().material = keyMat;
                    }
                    else if (keys[i].name == "Note1")
                    {
                        keys[i].GetComponent<Renderer>().material = code1;
                    }
                    else if (keys[i].name == "Note2")
                    {
                        keys[i].GetComponent<Renderer>().material = code2;
                    }
                    else if (keys[i].name == "Note3")
                    {
                        keys[i].GetComponent<Renderer>().material = code3;
                    }
                    keys[i].GetComponent<ParticleSystem>().Stop();
                    sniffSFX.Stop();
                }
            }
        }
        else
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i].name == "Bedroom_Key")
                {
                    keys[i].GetComponent<Renderer>().material = keyMat2;
                }
                else if (keys[i].name == "Bathroom_Key")
                {
                    keys[i].GetComponent<Renderer>().material = keyMat;
                }
                else if (keys[i].name == "Note1")
                {
                    keys[i].GetComponent<Renderer>().material = code1;
                }
                else if (keys[i].name == "Note2")
                {
                    keys[i].GetComponent<Renderer>().material = code2;
                }
                else if (keys[i].name == "Note3")
                {
                    keys[i].GetComponent<Renderer>().material = code3;
                }
                keys[i].GetComponent<ParticleSystem>().Stop();
                sniffSFX.Stop();
            }
        }
    }
}
