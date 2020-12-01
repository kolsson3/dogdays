using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    public GameObject destroyedObject;

    private void OnCollisionEnter(Collision collision) {
        
        if (collision.collider.CompareTag("Floor"))
        {
            Instantiate (destroyedObject, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
