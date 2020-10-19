using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool locked = true;
    public bool open = false;
    public float openThresh = 1f;

    public AudioClip doorLocked;
    public AudioClip unlock;
    public AudioSource source;

    void OnMouseDown()
    {
        Vector3 Dest = GameObject.Find("Target").transform.position;
        float distance = Vector3.Distance(Dest, this.transform.position);
        if (distance <= openThresh)
        {
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
                GetComponent<Animator>().SetTrigger("Shake");
                source.PlayOneShot(doorLocked, 1.0f);
            }
        }
    }

    public void Unlock()
    {
        locked = false;
        source.PlayOneShot(unlock, 1.0f);
    }
}
