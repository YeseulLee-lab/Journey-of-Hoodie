using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMod : MonoBehaviour
{
    public GameObject Jaeryo;
    public GameObject BuildingCrack;
    public bool destroying;

    // Start is called before the first frame update
    void Start()
    {
        destroying = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickDestroy(){
        GameObject.Find("Select").SetActive(false);
        
    }

    public void OnclickRestore(){
        GameObject.Find("Select").SetActive(false);
        GameObject.Find("Player").GetComponent<MapIcePlayer>().Allpercent = 100 - GameObject.Find("Player").GetComponent<MapIcePlayer>().Allpercent;
        Jaeryo.SetActive(false);
        BuildingCrack.SetActive(true);
        destroying = false;
    }
}
