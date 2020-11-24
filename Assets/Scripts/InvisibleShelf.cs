using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleShelf : MonoBehaviour
{
    public float FloatStrenght;
     public float RandomRotationStrenght;
     
     
     void Update () {
         transform.GetComponent<Rigidbody>().AddForce(Vector3.up *FloatStrenght);
          transform.Rotate(RandomRotationStrenght,RandomRotationStrenght,RandomRotationStrenght);
     }
}
