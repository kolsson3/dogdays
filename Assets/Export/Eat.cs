using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{

    public AudioSource eatSound;
    public AudioClip eat;

    void OnMouseDown()
    {
        if (gameObject.tag == "Food")
        {
            eatSound.PlayOneShot(eat, 1.0f);
        }
        Destroy(gameObject);
    }
}
