using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup2 : MonoBehaviour
{
    public Transform destination;
    bool grabbed = false;
    private float grabThreshold = 1f;
    private Color startcolor;
    void Start()
    {
        startcolor = GetComponent<Renderer>().material.color;
    }

    void OnMouseEnter()
    {
        if (Vector3.Distance(transform.position, destination.position) < grabThreshold) GetComponent<Renderer>().material.color = Color.yellow;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = startcolor;
    }

    void Update()
    {
        if(grabbed)
        {
            transform.position = Vector3.MoveTowards(destination.transform.position, transform.position, Time.deltaTime);
        }
    }
    void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, destination.position) < grabThreshold)
        {
            grabbed = true;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ
                                        | RigidbodyConstraints.FreezePositionX
                                        | RigidbodyConstraints.FreezePositionY
                                        | RigidbodyConstraints.FreezeRotationX
                                        | RigidbodyConstraints.FreezeRotationY
                                        | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    void OnMouseUp()
    {
        if(grabbed)
        {
            grabbed = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
        
    }
}
