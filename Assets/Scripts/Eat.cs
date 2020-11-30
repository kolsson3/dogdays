using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{

    //public AudioSource eatSound;

    void OnMouseDown()
    {
        if (gameObject.tag == "Food")
        {
            GetComponent<AudioSource>().Play();
            Debug.Log("here");
        }
        Destroy(gameObject);
    }
}
