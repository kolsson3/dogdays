using UnityEngine;

//Script to handle opening the secret door in the basement.
public class SecretDoor : MonoBehaviour
{
    public float openThresh = 2f;
    public GoalManager gm;
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Target");
    }

    void OnMouseDown()
    {
        //Track player location and open the door if they click on it close enough.
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= openThresh)
        {
            GetComponent<Animator>().SetTrigger("Open");
            gm.Complete("safe_get");
        }
    }
}
