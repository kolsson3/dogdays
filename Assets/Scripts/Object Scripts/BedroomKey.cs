using UnityEngine;

//Script for triggering a door unlock with the bedroom key.
public class BedroomKey : MonoBehaviour
{
    public OpenDoor door;
    public GoalManager goal; 

    private void OnTriggerEnter(Collider other)
    {
        //Checks for a trigger collider on a specific object.
        if (other.gameObject.name == "BedroomKnob")
        {
            //Unlocks the assigned door.
            door.Unlock();
            goal.Complete("bedroom");
        }
    }
}
