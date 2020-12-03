using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public Material stand;
    public Material vis;
    public GameObject sniffAbility;

    //void Start()
    //{
    //    GetComponent<Renderer>().material = stand;
    //}

    void Update()
    {
        if (!sniffAbility)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GetComponent<Renderer>().material = vis;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                GetComponent<Renderer>().material = stand;
            }
        }
    }
}
