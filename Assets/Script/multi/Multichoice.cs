using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multichoice : MonoBehaviour
{
    public GameObject DataObject;
    //public GameObject NetworkManager;
   // public GameObject SpawnPosition1;
  //  public GameObject SpawnPosition2;
  //  public GameObject Timeline;
   // public GameObject Camera;
    public GameObject Multi;
    public GameObject HostClient;
    public GameObject Photon;
    // Start is called before the first frame update
    void Start()
    {
        if(null != GameObject.Find("DataObject")){
            DataObject = GameObject.Find("DataObject");
            Multi.SetActive(true);
        }
        else{
            Multi.SetActive(false);
            return;
        }

     //   Multi = GameObject.Find("MULTI");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void MultiYes(){
     //   NetworkManager.SetActive(true);
    //    SpawnPosition1.SetActive(true);
    //    SpawnPosition2.SetActive(true);
        Multi.SetActive(false);
       // HostClient.SetActive(true);

        Photon.SetActive(true);
    }

    public void MultiNo(){
      //  Timeline.SetActive(true);
      //  Camera.SetActive(true);
        Multi.SetActive(false);
    }
}
