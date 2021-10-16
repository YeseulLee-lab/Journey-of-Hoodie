using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;//path사용위해

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
            CreateController();//플레이어 컨트롤러 붙여준다. 
        }
    }
    void CreateController()//플레이어 컨트롤러 만들기
    {
        Debug.Log("Instantiated Player Controller");
        if(PV.ViewID == 1001){
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "MultiPlayer"), spawnPositin.transform.position, spawnPositin.transform.rotation);            
        }
        else{
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "MultiPlayer"), spawnPositin.transform.position, spawnPositin.transform.rotation);
        }
    }
}