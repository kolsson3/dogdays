using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform destination;
    public float grabThreshold = 1f;
    public bool grabbed = false;
    

    Vector3 startPos;
    bool scored = false;
    private float scoreThresh = 0.25f;
    private Color startcolor;
    public int value = 1;
    public ScoreManager sm;
    Transform oParent;

    public AudioSource source;
    public AudioClip pickupSFX;


    void Start()
    {
        startPos = this.transform.position;
        startcolor = GetComponent<Renderer>().material.color;
        oParent = this.transform.parent;
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
        if (grabbed)
        {
            transform.position = Vector3.MoveTowards(destination.position, transform.position, Time.deltaTime);
        }
    }


    void OnMouseEnter()
    {
        if (Vector3.Distance(transform.position, destination.position) < grabThreshold) GetComponent<Renderer>().material.color = Color.yellow;
    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = startcolor;
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
            this.transform.parent = destination;
            source.PlayOneShot(pickupSFX, 1.0f);
        }
    }

    void OnMouseUp()
    {
        if (grabbed)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().useGravity = true;
            grabbed = false;
            this.transform.parent = oParent;
        }
    }
}
