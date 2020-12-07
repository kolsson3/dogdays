using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script handling the secret basement safe.
public class Safe : MonoBehaviour
{
    public float openThresh = 1f;
    public ScoreManager scoreManager;
    public GoalManager gm;
    bool opened = false;
    //Values tracking the input combination.
    public int L1 = 0;
    public int R2 = 0;
    public int L3 = 0;
    //Audio objects for playing safe sounds.
    public AudioClip unlock;
    public AudioClip wrong;
    public AudioSource source;
    //GameObject references for the player, door, handle, and empty objects representing either side of the safe.
    private GameObject player;
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
        player = GameObject.Find("Target");
    }

    void Update()
    {
        //If the safe isn't already opened, and the combination correct, open it.
        if (!opened && L1 == 3 && R2 == 1 && L3 == 2)
        {
            opened = true;
            //Activate empty object with safe contents, was causing issues with unlocking when starting active.
            transform.GetChild(0).gameObject.SetActive(true);
            //Deactivate empty colliders.
            left.SetActive(false);
            right.SetActive(false);
            //Set animation to open door.
            door.GetComponent<Animator>().SetTrigger("Open");
            //Increase score and complete goal.
            scoreManager.BlowUp(1000);
            gm.Complete("safe_open");
        }
    }

    void OnMouseDown()
    {
        //Get the player's distance to the left and right sides of the safe.
        Vector3 dest = player.transform.position;
        float dToLeft = Vector3.Distance(dest, left.transform.position);
        float dToRight = Vector3.Distance(dest, right.transform.position);
        //If safe not opened, and player is close enought to at least one side.
        if (!opened && (dToLeft <= openThresh || dToRight <= openThresh))
        {
            //Trigger the side the player is closest to and play sound.
            if (dToLeft < dToRight) Left();
            else Right();
            source.PlayOneShot(unlock, 1.0f);
        }
    }

    public void Left()
    {
        //Animate handle spin.
        handle.GetComponent<Animator>().Play("SafeLeft");
        //If first two combos are right, increment.
        if (L1 == 3 && R2 == 1) L3++;
        else if (L1 >= 3)
        {
            //If first combo goes over, play error sound and reset.
            source.PlayOneShot(wrong, 1.0f);
            L1 = 0;
            R2 = 0;
            L3 = 0;
        }
        else L1++;
    }

    public void Right()
    {
        //Animate handle spin.
        handle.GetComponent<Animator>().Play("SafeRight");
        //If first combo is correct and second hasn't hit yet, increment.
        if (L1 == 3 && R2 < 1) R2++;
        else
        {
            //First combo is wrong or second went over, play error sound and reset.
            source.PlayOneShot(wrong, 1.0f);
            L1 = 0;
            R2 = 0;
            L3 = 0;
        }
    }
}
