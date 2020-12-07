using UnityEngine;

//Script to handle door opening.
public class OpenDoor : MonoBehaviour
{
    //Bools for open, lock, and an open distance.
    public bool locked = true;
    public bool open = false;
    public float openThresh = 1f;
    //Audio objects.
    public AudioClip doorLocked;
    public AudioClip unlock;
    public AudioSource source;
    //Player location
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Target");
    }
    void OnMouseDown()
    {
        //Dest distance between player and doorknob, compare against threshold.
        Vector3 dest = player.transform.position;
        Vector3 Knob = gameObject.transform.GetChild(0).transform.position;
        float distance = Vector3.Distance(dest, Knob);
        if (distance <= openThresh)
        {
            //If not locked, rotate door open or shut.
            if (!locked)
            {
                if (open)
                {
                    this.transform.Rotate(0f, -75f, 0f, Space.World);
                    open = false;
                }
                else
                {
                    this.transform.Rotate(0f, 75f, 0f, Space.World);
                    open = true;
                }
            }
            else
            {
                //If Locked, play shake animation and sound.
                GetComponent<Animator>().SetTrigger("Shake");
                source.PlayOneShot(doorLocked, 1.0f);
            }
        }
    }

    public void Unlock()
    {
        //Unlock function called by key when triggered.
        locked = false;
        source.PlayOneShot(unlock, 1.0f);
    }
}
