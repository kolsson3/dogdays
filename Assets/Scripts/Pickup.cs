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
    private Color startcolor;
    public int value = 1;
    public ScoreManager sm;
    Transform oParent;

    private Material opaque;
    private Material transparent;
    private Renderer rend;

    public AudioSource source;
    public AudioClip pickupSFX;

    void Start()
    {
        source = GetComponent<AudioSource>();
        sm = GameObject.Find("Score").GetComponent<ScoreManager>();
        destination = GameObject.Find("Target").transform;
        rend = GetComponent<Renderer>();
        opaque = rend.material;
        transparent = Resources.Load("PolygonTown_01_O", typeof(Material)) as Material;
        startPos = this.transform.position;
        startcolor = rend.material.color;
        oParent = this.transform.parent;
    }

    void Update()
    {
        if(!grabbed && !scored)
        {
            if(Vector3.Distance(this.transform.position, startPos) > scoreThresh)
            {
                sm.Increase(value, this.gameObject);
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
        if (Vector3.Distance(transform.position, destination.position) < grabThreshold && !grabbed) GetComponent<Renderer>().material.color = Color.yellow;
    }
    void OnMouseExit()
    {
        if(!grabbed) GetComponent<Renderer>().material.color = startcolor;
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
            rend.material = transparent;
            if(source != null) source.PlayOneShot(pickupSFX, 1.0f);
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
            rend.material = opaque;
        }
    }
}
