using UnityEngine;

public class BathroomKey : MonoBehaviour
{
    public OpenDoor door;
    private Vector3 origin;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bathroom_Lock")
        {
            Debug.Log(other.gameObject.name);
            door.Unlock();
        }
    }
}
