using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSound : MonoBehaviour
{
    
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    
    private void OnCollisionEnter(Collision other) {
        source.Play();
        Destroy(GetComponent<BoxCollider>());
    }
}
