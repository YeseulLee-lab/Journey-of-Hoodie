using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;//포톤 기능 사용
using Photon.Realtime;
using System.Linq;

public class Launcher : MonoBehaviourPunCallbacks//다른 포톤 반응 받아들이기
{
    public InputField RoomNametext;
    public Text RoomName;
    public string icenickname;
  //  public InputField FindRoomNametext;
    [SerializeField] Transform roomListContent;
    [SerializeField] GameObject roomListItemPrefab;
    [SerializeField] Transform playerListContent;
    [SerializeField] GameObject playerListItemPrefab;
   // public GameObject CreateRoomafter;
  //  public GameObject RoomName;
    void Start()
    {
        Debug.Log("Connecting to Master");
        PhotonNetwork.ConnectUsingSettings();//설정한 포톤 서버에 때라 마스터 서버에 연결

        if(null != GameObject.Find("DataObject")){
            icenickname = GameObject.Find("DataObject").GetComponent<TransData>().icenickname;
        }
        else{
            icenickname = "아이스";
        }
    }

   /* public void StartServer()
    {
        Debug.Log("Connecting to Master");
        PhotonNetwork.ConnectUsingSettings();//설정한 포톤 서버에 때라 마스터 서버에 연결
    }*/

    public override void OnConnectedToMaster()//마스터서버에 연결시 작동됨
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();//마스터 서버 연결시 로비로 연결
    }

    public override void OnJoinedLobby()//로비에 연결시 작동
    {

        Debug.Log("Joined Lobby");

        PhotonNetwork.NickName = icenickname;
       // GameObject.Find("icenicknameObject").GetComponent<nicknameObject>().icenickname;
        //들어온사람 이름 랜덤으로 숫자붙여서 정해주기
    }

    public void CreateRoom()//방만들기
    {
     //   StartServer();
        if (string.IsNullOrEmpty(RoomNametext.text))
        {
            return;//방 이름이 빈값이면 방 안만들어짐
        }
        PhotonNetwork.CreateRoom(RoomNametext.text);//포톤 네트워크기능으로 roomNameInputField.text의 이름으로 방을 만든다.
       // transform.Find("loading").gameObject.SetActive(true);
        // GameObject.Find("Create Room after").SetActive(false);
        // GameObject.Find("RoomName").SetActive(false);
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);//포톤 네트워크의 JoinRoom기능 해당이름을 가진 방으로 접속한다. 
        //MenuManager.Instance.OpenMenu("loading");//로딩창 열기
    }

    public override void OnJoinedRoom()//방에 들어갔을때 작동
    {
        RoomName.text = PhotonNetwork.CurrentRoom.Name;//들어간 방 이름표시
        Player[] players = PhotonNetwork.PlayerList;
        for (int i = 0; i < players.Count(); i++)
        {
            print(players[i]);
            Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
            //내가 방에 들어가면 방에있는 사람 목록 만큼 이름표 뜨게 하기
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)//포톤의 룸 리스트 기능
    {
        foreach (Transform trans in roomListContent)//존재하는 모든 roomListContent
        {
            Destroy(trans.gameObject);//룸리스트 업데이트가 될때마다 싹지우기
        }
        for (int i = 0; i < roomList.Count; i++)//방갯수만큼 반복
        {
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
            //instantiate로 prefab을 roomListContent위치에 만들어주고 그 프리펩은 i번째 룸리스트가 된다. 
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)//다른 플레이어가 방에 들어오면 작동
    {
        Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
        //instantiate로 prefab을 playerListContent위치에 만들어주고 그 프리펩을 이름 받아서 표시. 
    }
}