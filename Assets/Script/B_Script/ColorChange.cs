using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorChange : MonoBehaviour
{
    public Material icecolorChoco;
    public Material icecolorMint;
    public string icekind;
    public string othericekind;
    public GameObject[] Player;
    // Start is called before the first frame update
    void Start()
    {
       // if(null != GameObject.Find("DataObject")){
        //    icekind = GameObject.Find("icenicknameObject").GetComponent<nicknameObject>().icekind;
        //}
        
        if(null != GameObject.Find("DataObject")){
            icekind = GameObject.Find("DataObject").GetComponent<TransData>().icekind;
        }
        else if(null != GameObject.Find("icenicknameObject")){
            icekind = GameObject.Find("icenicknameObject").GetComponent<nicknameObject>().icekind;
           // GameObject.Find("MultiPlayer(Clone)").GetComponent<IcePlayer>().PV.RPC("getColor", RpcTarget.All, icekind);
        }
        else{
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        GameObject.Find("MultiPlayer(Clone)").GetComponent<IcePlayer>().PV.RPC("getColor", RpcTarget.Others, icekind);

        if(SceneManager.GetActiveScene().name == "B"){
            if(null != GameObject.Find("MultiPlayer(Clone)"))
            {
                if(icekind == "Mint"){
                    Player[0].transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorMint;
                }
                else if(icekind == "Choco"){
                    Player[0].transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorChoco;
                }
                else if(othericekind == "Mint"){
                    Player[1].transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorMint;
                }
                else if(othericekind == "Choco"){
                    Player[1].transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorChoco;
                }
            }
            else
            {
                if(null != GameObject.Find("Player"))
                {
                    if(icekind == "Mint"){
                        Player[0].transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorMint;
                    }
                    else if(icekind == "Choco"){
                        Player[0].transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorChoco;
                    }
                }
            }
        }
    }
}