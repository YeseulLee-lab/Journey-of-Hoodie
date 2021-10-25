using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;//path사용위해
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;//포톤뷰 선언
    GameObject spawnPositin;
    GameObject spawnPositinPudding;
    GameObject spawnPositinBread;
    GameObject spawnPositinCheese;
    void Awake()
    {
        PV = GetComponent<PhotonView>();   
    }

    void Start()
    {
        spawnPositin = GameObject.Find("SpawnPosition");
        spawnPositinPudding = GameObject.Find("SpawnPositionPudding");
        spawnPositinBread = GameObject.Find("SpawnPositionBread");
        spawnPositinCheese = GameObject.Find("SpawnPositionCheese");

        if (PV.IsMine)//내 포톤 네트워크이면
        {
            if(SceneManager.GetActiveScene().name == "B"){
                CreateController();//플레이어 컨트롤러 붙여준다. 
            }
            else if(SceneManager.GetActiveScene().name == "Pudding" || SceneManager.GetActiveScene().name == "Bread" || SceneManager.GetActiveScene().name == "Cheese"){
                CreateTownController();
            }
        }
    }
    void CreateController()//플레이어 컨트롤러 만들기
    {
        Debug.Log("Instantiated Player Controller");
        if(null == GameObject.Find("DeleteTimeline"))
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "MultiPlayer"), spawnPositin.transform.position, spawnPositin.transform.rotation);
        }
        else if(null != GameObject.Find("Pudding"))
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "MultiPlayer"), spawnPositinPudding.transform.position, spawnPositinPudding.transform.rotation);
        }
        else if(null != GameObject.Find("Bread"))
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "MultiPlayer"), spawnPositinBread.transform.position, spawnPositinBread.transform.rotation);
        }
        else if(null != GameObject.Find("Cheese"))
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "MultiPlayer"), spawnPositinCheese.transform.position, spawnPositinCheese.transform.rotation);
        }
    }

    void CreateTownController()//플레이어 컨트롤러 만들기
    {
        Debug.Log("Instantiated Player Controller");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "TownMultiPlayer"), spawnPositin.transform.position, spawnPositin.transform.rotation);
    }
}