using UnityEngine;

public class BathroomKey : MonoBehaviour
{
    public OpenDoor door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bathroom_Lock")
        {
            Debug.Log(other.gameObject.name);
            door.Unlock();
        }
    }
}
