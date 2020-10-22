using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform destination;
    public float grabThreshold = 1f;
    bool grabbed = false;
    

    Vector3 startPos;
    bool scored = false;
    private float scoreThresh = 0.25f;
    public int value = 1;
    public ScoreManager sm;

    void Start()
    {
        startPos = this.transform.position;
    }

    void Update()
    {
        if(!grabbed && !scored)
        {
            if(Mathf.Abs(this.transform.position.x - startPos.x) > scoreThresh)
            {
                sm.Increase(value);
                scored = true;
            }
        }
    }

    void OnMouseDown()
    {
        Vector3 Dest = GameObject.Find("Target").transform.position;
        float distance = Vector3.Distance(Dest, this.transform.position);
        Debug.Log(distance); 
        if(distance <= grabThreshold)
        {
            grabbed = true;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ
                                        | RigidbodyConstraints.FreezePositionX
                                        | RigidbodyConstraints.FreezePositionY
                                        | RigidbodyConstraints.FreezeRotationX
                                        | RigidbodyConstraints.FreezeRotationY
                                        | RigidbodyConstraints.FreezeRotationZ;
            this.transform.position = destination.position;
            this.transform.parent = GameObject.Find("Target").transform;
        }
    }

    void OnMouseUp()
    {
        if (grabbed)
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().useGravity = true;
            grabbed = false;
        }
        
    }

}
