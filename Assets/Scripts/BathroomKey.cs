using UnityEngine;

public class BathroomKey : MonoBehaviour
{
    public OpenDoor door;
    //public ParticleSystem ps;
    //public Pickup pu;
    //public GameObject sniffAbility;
    //bool found = false;
    
    private Vector3 origin;
    public GoalManager goal;

    void Start()
    {
        origin = transform.position;
    }

    void Update()
    {
        if (this.transform.position.y < -0.1f)
        {
            this.transform.position = origin;
        }
        //if (pu.grabbed == true)
        //{
        //    found = true;
        //}
        //if (found == true)
        //{
        //    ps.enableEmission = false;
        //}
        //else
        //{
        //    if (!sniffAbility)
        //    {
        //        if (Input.GetKeyDown(KeyCode.E))
        //        {
        //            ps.Play();
        //        }
        //        if (Input.GetKeyUp(KeyCode.E))
        //        {
        //            ps.Stop();
        //        }
        //    }
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BathroomKnob")
        {
            door.Unlock();
            goal.Complete("bathroom");
        }
    }
}
