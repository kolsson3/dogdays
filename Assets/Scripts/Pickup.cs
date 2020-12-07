using UnityEngine;

//Script handling objects that can be picked up by the player.
public class Pickup : MonoBehaviour
{
    public Transform destination; //Destination when picked up.
    private Transform oParent; //Original parent of object.
    public int value = 1; // Value of the object.
    public float grabThreshold = 1f; //Distance the player can grab from.
    private float scoreThresh = 0.25f; //Distance the object has to move to be scored.
    bool grabbed = false; //Is the object grabbed?
    bool scored = false; //Has the object been score?
    Vector3 startPos; //Start position of the object.
    private Color startcolor; //Initial color of object.
    public ScoreManager sm; //Score manager reference.
    //Materials and renderer for setting highlight and transparency.
    private Material opaque;
    private Material transparent;
    private Renderer rend;

    //Audio source and clip for pickup sounds.
    public AudioSource source;
    public AudioClip pickupSFX;

    void Start()
    {
        //Set defined variables.
        source = GetComponent<AudioSource>();
        //Score Manager and Target are set through GameObject Find. Less efficient, but easier for fast development.
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
        //If not grabbed and not scored...
        if(!grabbed && !scored)
        {
            //Check if object has moved beyond its score threshold.
            if(Vector3.Distance(this.transform.position, startPos) > scoreThresh)
            {
                //Increase score and set bool to not re-score object.
                sm.Increase(value);
                scored = true;
                Debug.Log(gameObject.name);
            }
        }
        //If the object is grabbed, move it towards target.
        if (grabbed) transform.position = Vector3.MoveTowards(destination.position, transform.position, Time.deltaTime);
    }

    //On mouse enter, if within grab threshold and not grabbed, apply highlight.
    void OnMouseEnter()
    {
        if (Vector3.Distance(transform.position, destination.position) < grabThreshold && !grabbed) GetComponent<Renderer>().material.color = Color.yellow;
    }

    //On mouse exit, remove highlight.
    void OnMouseExit()
    {
        if(!grabbed) GetComponent<Renderer>().material.color = startcolor;
    }

    void OnMouseDown()
    {   
        //On mouse down, if within grab threshold; apply rigidbody constraints, set target as parent, render transparency, and play sound if one is set.
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
            this.transform.parent = destination; //Set target as parent.
            rend.material = transparent; //Set transparent material.
            if(source != null) source.PlayOneShot(pickupSFX, 1.0f); //Play sound if one is supplied to the script.
        }
    }

    void OnMouseUp()
    {
        //If the object is grabbed; reset rigidbody constraints, parent, and material.
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
