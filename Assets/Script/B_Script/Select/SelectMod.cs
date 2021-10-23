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
        GameObject.Find("Player").GetComponent<MapIcePlayer>().percent = 100 - GameObject.Find("Player").GetComponent<MapIcePlayer>().percent;
        GameObject.Find("Player").GetComponent<MapIcePlayer>().Allpercentmid = 300 - GameObject.Find("Player").GetComponent<MapIcePlayer>().Allpercentmid;
        Jaeryo.SetActive(false);
        BuildingCrack.SetActive(true);
        destroying = false;
        GameObject.Find("SaveManager").GetComponent<Bpercent>().state = destroying;

        GameObject.Find("SaveManager").GetComponent<Bpercent>().percent1 = 100 - GameObject.Find("SaveManager").GetComponent<Bpercent>().percent1;
        GameObject.Find("SaveManager").GetComponent<Bpercent>().percent2 = 100 - GameObject.Find("SaveManager").GetComponent<Bpercent>().percent2;
        GameObject.Find("SaveManager").GetComponent<Bpercent>().percent3 = 100 - GameObject.Find("SaveManager").GetComponent<Bpercent>().percent3;
    }
}
