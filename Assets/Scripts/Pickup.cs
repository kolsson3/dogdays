using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform destination;
    public float grabThreshold = 5f;

    void OnMouseDown()
    {
        Vector3 Dest = GameObject.Find("Dest").transform.position;
        float distance = Vector3.Distance(Dest, this.transform.position);
        Debug.Log(distance); 
        if(distance <= grabThreshold)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ
                                        | RigidbodyConstraints.FreezePositionX
                                        | RigidbodyConstraints.FreezePositionY
                                        | RigidbodyConstraints.FreezeRotationX
                                        | RigidbodyConstraints.FreezeRotationY
                                        | RigidbodyConstraints.FreezeRotationZ;
            this.transform.position = destination.position;
            this.transform.parent = GameObject.Find("Dest").transform;
        }
    }

    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<Rigidbody>().useGravity = true;
    }

}
