using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateFragments : MonoBehaviour
{
    public ScoreManager sm;
    public int value = 2;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Floor")
        {
            GetComponent<Collider>().isTrigger = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

}