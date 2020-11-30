using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKeys : MonoBehaviour
{
    public GameObject bathKey;
    public GameObject bathKeyPos1;
    public GameObject bathKeyPos2;
    public GameObject bathKeyPos3;
    public GameObject bedKey;
    public GameObject bedKeyPos1;
    public GameObject bedKeyPos2;
    public GameObject bedKeyPos3;

    void Start()
    {
        GameObject[] bathKeyposList =  { bathKeyPos1, bathKeyPos2, bathKeyPos3 };
        GameObject[] bedKeyposList =  { bedKeyPos1, bedKeyPos2, bedKeyPos3 };
        int bathKeyPos = (int)Random.Range(0, 3);
        int bedKeyPos = (int)Random.Range(0, 3);
        bathKey.transform.position = bathKeyposList[bathKeyPos].transform.position;
        bathKey.SetActive(true);
        bedKey.transform.position = bedKeyposList[bathKeyPos].transform.position;
        bedKey.SetActive(true);
    }


}
