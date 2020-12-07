using UnityEngine;

//Script for triggering a door unlock with the bedroom key.
public class BathroomKey : MonoBehaviour
{
    public OpenDoor door;
    public GoalManager goal;

    private void OnTriggerEnter(Collider other)
    {
        //Checks for a trigger collider on a specific object.
        if (other.gameObject.name == "BathroomKnob")
        {
            //Unlocks the assigned door.
            door.Unlock();
            goal.Complete("bathroom");
        }
    }
}
