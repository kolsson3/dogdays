using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool locked = true;
    public bool open = false;
    public float openThresh = 1f;

    void OnMouseDown()
    {
        Vector3 Dest = GameObject.Find("Target").transform.position;
        float distance = Vector3.Distance(Dest, this.transform.position);
        Debug.Log(distance);
        if (distance <= openThresh)
        {
            if (!locked)
            {
                if (open)
                {
                    this.transform.Rotate(0f, -55f, 0f, Space.World);
                    open = false;
                }
                else
                {
                    this.transform.Rotate(0f, 55f, 0f, Space.World);
                    open = true;
                }
            }
            else
            {
                GetComponent<Animator>().SetTrigger("Shake");
            }
        }
    }

    public void Unlock()
    {
        locked = false;
    }
}
