using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterTown : MonoBehaviour
{
    //SavePlayerPos playerPosData;
    IcePlayer Player;
    public Text TownName;
    GameObject DeleteManager;
    GameObject puddingpercent;
    GameObject breadpercent;
    GameObject cheesepercent;
    GameObject percentManager;
    public GameObject[] MultiPlayer;
    void Start()
    {
        //playerPosData = FindObjectOfType<SavePlayerPos>();
        Player = FindObjectOfType<IcePlayer>();
        DeleteManager = GameObject.Find("DeleteTimeline");
        puddingpercent = GameObject.Find("puddingpercent");
        breadpercent = GameObject.Find("breadpercent");
        cheesepercent = GameObject.Find("cheesepercent");
        percentManager = GameObject.Find("SaveManager");
    }

    // Start is called before the first frame update
    public void Enter(){
        // playerPosData.PlayerPosSave();
        SavePlayerPos.SavePlayer(Player);
        SceneManager.LoadScene("Pudding");
    }

    void Update(){
        MultiPlayer = GameObject.FindGameObjectsWithTag("Player");
        

        if(gameObject.activeSelf == true){
            if(Input.GetButtonDown("Cancel")){
                gameObject.SetActive(false);
            }
            if(Input.GetButtonDown("Enter")){
                // playerPosData.PlayerPosSave();
                SavePlayerPos.SavePlayer(Player);
                if(TownName.text == "푸딩마을"){
                    if(null != MultiPlayer[0].GetComponent<IcePlayer>().PV){
                        MultiPlayer[0].GetComponent<IcePlayer>().PV.RPC("Sceneunify", Photon.Pun.RpcTarget.AllBuffered, "Pudding");
                    }
                    SceneManager.LoadScene("Pudding");
                    Destroy(DeleteManager);
                }
                else if(TownName.text == "빵마을"){
                    if(null != MultiPlayer[0].GetComponent<IcePlayer>().PV){
                        MultiPlayer[0].GetComponent<IcePlayer>().PV.RPC("Sceneunify", Photon.Pun.RpcTarget.AllBuffered, "Bread");
                    }
                    SceneManager.LoadScene("Bread");
                    Destroy(DeleteManager);
                }
                else if(TownName.text == "치즈마을"){
                    if(null != MultiPlayer[0].GetComponent<IcePlayer>().PV){
                        MultiPlayer[0].GetComponent<IcePlayer>().PV.RPC("Sceneunify", Photon.Pun.RpcTarget.AllBuffered, "Cheese");
                    }
                    SceneManager.LoadScene("Cheese");
                    Destroy(DeleteManager);
                }
            }
        }
    }
}