using UnityEngine;

//Script handling the fragments of glass in the showers.
public class GlassFragment : MonoBehaviour
{
    public ScoreManager sm;
    public int value = 5;
    public AudioClip smash;
    public AudioSource source;

    void OnTriggerEnter(Collider other)
    {
        //Check if the player or a child of the player has entered the trigger. This allows the player to use objects to hit shards higher up.
        if (other.gameObject.name == "Player" || other.transform.parent.gameObject.name == "Target")
        {
            //Remove freeze constraints on the rigidbody so it falls.
            GetComponent<Collider>().isTrigger = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            //Add some score.
            sm.Increase(value);
            //Play the smash sound.
            if(!source.isPlaying) source.PlayOneShot(smash, 1.0f);
        }
    }   
}
