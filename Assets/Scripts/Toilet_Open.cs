using UnityEngine;

public class Toilet_Open : MonoBehaviour
{
    public bool open = true;
    public float openThresh = 1f;

    void OnMouseDown()
    {
        Vector3 Dest = GameObject.Find("Target").transform.position;
        float distance = Vector3.Distance(Dest, this.transform.position);
        if (distance <= openThresh)
        {
                if (open)
                {
                    this.transform.Rotate(90f, 0f, 0f, Space.World);
                    open = false;
                }
                else
                {
                    this.transform.Rotate(-90f, 0f, 0f, Space.World);
                    open = true;
                }
        }
    }

}
