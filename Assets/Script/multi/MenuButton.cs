using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
  //  public InputField RoomNametext;
    public GameObject CreateRoomafter;
    public GameObject Find;
    public GameObject Photon;
   // public GameObject RoomName;
    // Start is called before the first frame update
    public void CreateTrue(){
        CreateRoomafter.SetActive(true);
       // RoomName.SetActive(true);
        GameObject.Find("Create Room").SetActive(false);
        GameObject.Find("Find Room").SetActive(false);
     //   Photon.GetComponent<Launcher>().StartServer();
    }

    public void FindTrue(){
        Find.SetActive(true);
        GameObject.Find("Create Room").SetActive(false);
        GameObject.Find("Find Room").SetActive(false);
    }

    public void CreateFalse(){
        CreateRoomafter.SetActive(false);
        GameObject.Find("Photon").transform.Find("Create Room").gameObject.SetActive(true);
        GameObject.Find("Photon").transform.Find("Find Room").gameObject.SetActive(true);
    }

    public void FindFalse(){
        Find.SetActive(false);
        GameObject.Find("Photon").transform.Find("Create Room").gameObject.SetActive(true);
        GameObject.Find("Photon").transform.Find("Find Room").gameObject.SetActive(true);
    }

}
