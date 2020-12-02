using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    public AudioSource source;
    public AudioClip smash;
    public GameObject destroyedObject;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision) {
        
        if (collision.collider.CompareTag("Floor"))
        {
            Instantiate (destroyedObject, transform.position, transform.rotation);
            //source.PlayOneShot(smash, 1.0f);
            Destroy(this.gameObject);
        }
    }
}
