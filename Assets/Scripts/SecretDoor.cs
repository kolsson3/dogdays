using UnityEngine;

public class SecretDoor : MonoBehaviour
{
    public float openThresh = 1f;
    public GoalManager gm;

    void OnMouseDown()
    {
        Vector3 Dest = GameObject.Find("Target").transform.position;
        float distance = Vector3.Distance(Dest, this.transform.position);
        if (distance <= openThresh)
        {
            GetComponent<Animator>().SetTrigger("Open");
            gm.Complete("safe_get");
        }
    }

}
