using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    public float openThresh = 1f;
    public Safe safe;

    public int L1 = 0;
    public int R2 = 0;
    public int L3 = 0;

    bool opened = false;
    public AudioClip unlock;
    public AudioClip wrong;

    public AudioSource source;
    public ScoreManager scoreManager;
    public GoalManager gm;

    void Update()
    {
        if (L1 == 3 && R2 == 1 && L3 == 2 && !opened)
        {
            GameObject.Find("SafeDoor").GetComponent<Animator>().SetTrigger("Open");
            opened = true;
            scoreManager.BlowUp(1000);
            GameObject.Find("Left").SetActive(false);
            GameObject.Find("Right").SetActive(false);
            gm.Complete("safe_open");
        }
    }

    void OnMouseDown()
    {
        Vector3 Dest = GameObject.Find("Target").transform.position;
        float distance = Vector3.Distance(Dest, this.transform.position);
        if (!opened && distance <= openThresh)
        {
            Left();
            Right();
            source.PlayOneShot(unlock, 1.0f);
        }
    }

    public void Left()
    {
        if (this.name == "Left")
        {
            if(safe.L1 == 3 && safe.R2 == 1)
            {
                safe.L3++;
            }
            else
            {
                source.PlayOneShot(wrong, 1.0f);
                safe.L3 = 0;
                safe.R2 = 0;
                safe.L1++;
            }
            if(safe.L1 > 3)
            {
                source.PlayOneShot(wrong, 1.0f);
                safe.L1 = 0;
            }
        }
    }

    public void Right()
    {
        if (this.name == "Right")
        {
            if(safe.L1 == 3) safe.R2++;
            else
            {
                source.PlayOneShot(wrong, 1.0f);
                safe.L1 = 0;
                safe.R2 = 0;
                safe.L3 = 0;
            }
        }
    }
}
