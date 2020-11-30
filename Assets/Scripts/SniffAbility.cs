using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniffAbility : MonoBehaviour
{

    public Material seeThru;
    public AudioSource sniffSFX;
    public Material keyMat;
    public Material parMat;
    public GameObject sniffFood;
    public float targetTime = 5.0f;


    GameObject[] keys;

    void Start()
    {
        keys = GameObject.FindGameObjectsWithTag("Key");
    }

    void Update()
    {
        if (!sniffFood)
        {
            targetTime -= Time.deltaTime;
            if (targetTime > 0.0f)
            {
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
                        keys[i].GetComponent<Renderer>().material = keyMat;
                        keys[i].GetComponent<ParticleSystem>().Stop();
                        sniffSFX.Stop();
                    }
                }
            }
        }
    }
}
