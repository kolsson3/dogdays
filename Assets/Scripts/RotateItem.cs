using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    //public GameObject gameObject;
    public ParticleSystem ps;
    public bool isTaken = false;
    public GameObject sniffAbility;


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            ps.enableEmission = false;
            isTaken = true;
        }
    }


    void Update()
    {
        transform.Rotate(new Vector3(0, Time.deltaTime * 50, 0));
        if (!sniffAbility)
        {
            if (ps.enableEmission == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ps.Play();
                }
                if (Input.GetKeyUp(KeyCode.E))
                {
                    ps.Stop();
                }
            }
        }
    }
}
