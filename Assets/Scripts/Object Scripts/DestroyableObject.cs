using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    //Public objects for score, audio and the replacement object.
    public ScoreManager sm;
    public AudioClip smash;
    public GameObject destroyedObject;

    void Start()
    {
        sm = GameObject.Find("Score").GetComponent<ScoreManager>();
    }

    private void OnCollisionEnter(Collision collision) 
    {
        //Check if collider is tagged as floor.
        if (collision.collider.CompareTag("Floor"))
        {
            //Create destroyed object, play audio, destroy original object, increase score.
            GameObject destroyed = Instantiate (destroyedObject, transform.position, transform.rotation);
            AudioSource source = destroyed.AddComponent(typeof(AudioSource)) as AudioSource;
            source.PlayOneShot(smash, 1.0f);
            sm.Increase(5);
            Destroy(this.gameObject);
        }
    }
}
