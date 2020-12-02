using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    public float openThresh = 1f;

    public int L1 = 0;
    public int R2 = 0;
    public int L3 = 0;

    bool opened = false;
    public AudioClip unlock;
    public AudioClip wrong;

    public AudioSource source;
    public ScoreManager scoreManager;
    public GoalManager gm;

    private GameObject door;
    private GameObject handle;
    private GameObject left;
    private GameObject right;

    void Start()
    {
        door = GameObject.Find("SafeDoor");
        handle = GameObject.Find("SafeHandle");
        left = GameObject.Find("Left");
        right = GameObject.Find("Right");
    }

    void Update()
    {
        if (!opened && L1 == 3 && R2 == 1 && L3 == 2)
        {
            transform.GetChild(0).gameObject.SetActive(true);
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
        Vector3 dest = GameObject.Find("Target").transform.position;
        float dToLeft = Vector3.Distance(dest, left.transform.position);
        float dToRight = Vector3.Distance(dest, right.transform.position);
        if (!opened && (dToLeft <= openThresh || dToRight <= openThresh))
        {
            if (dToLeft < dToRight) Left();
            else Right();
                source.PlayOneShot(unlock, 1.0f);
        }
    }

    public void Left()
    {
        handle.GetComponent<Animator>().Play("SafeLeft");
            if(L1 == 3 && R2 == 1)
            {
                L3++;
            }
        else if (L1 >= 3)
        {
            source.PlayOneShot(wrong, 1.0f);
            L1 = 0;
            R2 = 0;
            L3 = 0;
        }
        else
        {
            L1++;
        }
    }

    public void Right()
    {
        handle.GetComponent<Animator>().Play("SafeRight");
        if (L1 == 3 && R2 < 1) R2++;
            else
            {
                source.PlayOneShot(wrong, 1.0f);
                L1 = 0;
                R2 = 0;
                L3 = 0;
            }
    }
}
