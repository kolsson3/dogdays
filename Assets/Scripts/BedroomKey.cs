using UnityEngine;

public class BedroomKey : MonoBehaviour
{
    public OpenDoor door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bedroom_Lock")
        {
            Debug.Log(other.gameObject.name);
            door.Unlock();
        }
    }
}
