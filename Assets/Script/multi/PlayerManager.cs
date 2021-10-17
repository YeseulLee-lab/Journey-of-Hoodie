using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;//path사용위해
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;//포톤뷰 선언
    [SerializeField] GameObject spawnPositin;

    void Awake()
    {
        PV = GetComponent<PhotonView>();   
    }

    void Start()
    {
        spawnPositin = GameObject.Find("SpawnPosition");
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
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "MultiPlayer"), spawnPositin.transform.position, spawnPositin.transform.rotation);            
    }

    void CreateTownController()//플레이어 컨트롤러 만들기
    {
        Debug.Log("Instantiated Player Controller");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "TownMultiPlayer"), spawnPositin.transform.position, spawnPositin.transform.rotation);
    }
}