using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlot : MonoBehaviour
{
    public static InventorySlot instance;
    public Image icon;
    public Button ItemButton;
    public Text amountText;
    Item item;

    public GameObject small;
    public GameObject medium;
    public GameObject fork;
    public GameObject Building1;
    public GameObject Building2;
    public GameObject Building3;
    public GameObject select;
    public GameObject[] Player;
    public PhotonView PV;
    void Update() {
        Player = GameObject.FindGameObjectsWithTag("Player");
        //if(Player.Length == 2){
        small = Player[0].transform.Find("Bone002").transform.Find("Bone009").transform.Find("Bone030").transform.Find("SmallSpoon3D").gameObject;
        medium = Player[0].transform.Find("Bone002").transform.Find("Bone009").transform.Find("Bone030").transform.Find("MediumSpoon3D").gameObject;
        fork = Player[0].transform.Find("Bone002").transform.Find("Bone009").transform.Find("Bone030").transform.Find("Fork (1)").gameObject;
        PV = Player[0].GetComponent<PhotonView>();
        //}
       // else{
       //     return;
       // }
    }
    public void AddItem (Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        amountText.enabled = true;
        ItemButton.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        amountText.enabled = false;
        ItemButton.enabled = false;
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
            if(select.GetComponent<SelectMod>().destroying == true)
            {
                if(item.id == 100)
                {
                    small.SetActive(true);
                    if(null != PV){
                        Player[0].GetComponent<MapIcePlayer>().PV.RPC("smallItemMulti", RpcTarget.Others, true);
                    }
                    medium.SetActive(false);
                    fork.SetActive(false);
                }
                else if(item.id == 200)
                {
                    small.SetActive(false);
                    medium.SetActive(true);
                    if(null != PV){
                        Player[0].GetComponent<MapIcePlayer>().PV.RPC("mediumItemMulti", RpcTarget.Others, true);
                    }
                    fork.SetActive(false);
                }
                else if(item.id == 300)
                {
                    small.SetActive(false);
                    medium.SetActive(false);
                    fork.SetActive(true);
                    if(null != PV){
                        Player[0].GetComponent<MapIcePlayer>().PV.RPC("forkItemMulti", RpcTarget.Others, true);
                    }
                }
            }
            else if(select.GetComponent<SelectMod>().destroying == false)
            {
                small.SetActive(false);
                medium.SetActive(false);
                fork.SetActive(false);
                if(item.id == 1000)
                {
                    Building1.SetActive(true);
                    Building2.SetActive(false);
                    Building3.SetActive(false);
                }
                else if(item.id == 2000)
                {
                    Building1.SetActive(false);
                    Building2.SetActive(true);
                    Building3.SetActive(false);
                }
                else if(item.id == 3000)
                {
                    Building1.SetActive(false);
                    Building2.SetActive(false);
                    Building3.SetActive(true);
                }
            }
            
        }
    }


}