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
        if(gameObject.activeSelf == true){
            if(Input.GetButtonDown("Cancel")){
                gameObject.SetActive(false);
            }
            if(Input.GetButtonDown("Enter")){
                // playerPosData.PlayerPosSave();
                SavePlayerPos.SavePlayer(Player);
                if(TownName.text == "푸딩마을"){
                    if(null != Player.PV){
                        Player.PV.RPC("Sceneunify", Photon.Pun.RpcTarget.Others, "Pudding", percentManager);
                    }
                    SceneManager.LoadScene("Pudding");
                    DontDestroyOnLoad(percentManager);
                    Destroy(DeleteManager);
                }
                else if(TownName.text == "빵마을"){
                    if(null != Player.PV){
                        Player.PV.RPC("Sceneunify", Photon.Pun.RpcTarget.Others, "Bread", percentManager);
                    }
                    SceneManager.LoadScene("Bread");
                    DontDestroyOnLoad(percentManager);
                    Destroy(DeleteManager);
                }
                else if(TownName.text == "치즈마을"){
                    if(null != Player.PV){
                        Player.PV.RPC("Sceneunify", Photon.Pun.RpcTarget.Others, "cheese", percentManager);
                    }
                    SceneManager.LoadScene("Cheese");
                    DontDestroyOnLoad(percentManager);
                    Destroy(DeleteManager);
                }
            }
        }
    }
}
