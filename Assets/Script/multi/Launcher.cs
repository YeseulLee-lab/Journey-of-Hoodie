using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;//포톤 기능 사용
using Photon.Realtime;
using System.Linq;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviourPunCallbacks//다른 포톤 반응 받아들이기
{
    public InputField RoomNametext;
    public Text RoomName;
    public string icenickname;
    public GameObject[] Create;
    public GameObject FindLoading;
  //  public InputField FindRoomNametext;
    [SerializeField] Transform roomListContent;
    [SerializeField] GameObject roomListItemPrefab;
    [SerializeField] Transform playerListContent;
    [SerializeField] GameObject playerListItemPrefab;
   // public GameObject CreateRoomafter;
  //  public GameObject RoomName;
    void Start()
    {
        if(null != GameObject.Find("DataObject")){
            icenickname = GameObject.Find("DataObject").GetComponent<TransData>().icenickname;
        }
        else{
            icenickname = "아이스";
        }
    }
    
    public void StartServer()
    {
        Debug.Log("Connecting to Master");
        PhotonNetwork.ConnectUsingSettings();//설정한 포톤 서버에 때라 마스터 서버에 연결
    }

    public override void OnConnectedToMaster()//마스터서버에 연결시 작동됨
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();//마스터 서버 연결시 로비로 연결
        PhotonNetwork.AutomaticallySyncScene = true;//자동으로 모든 사람들의 scene을 통일 시켜준다.
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
        
        for(int i = 0; i < 4; i++){
            Create[i].SetActive(true);
        }

        for(int i = 4; i < 7; i++){
            Create[i].SetActive(false);
        }
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);//포톤 네트워크의 JoinRoom기능 해당이름을 가진 방으로 접속한다. 
        //MenuManager.Instance.OpenMenu("loading");//로딩창 열기
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();//방떠나기 포톤 네트워크 기능
        RoomNametext.text = null;
    }

    public override void OnJoinedRoom()//방에 들어갔을때 작동
    {
        RoomName.text = PhotonNetwork.CurrentRoom.Name;//들어간 방 이름표시
        Player[] players = PhotonNetwork.PlayerList;
        foreach (Transform child in playerListContent)
        {
            Destroy(child.gameObject);//방에 들어가면 전에있던 이름표들 삭제
        }
        for (int i = 0; i < players.Count(); i++)
        {
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
            if (roomList[i].RemovedFromList)//사라진 방은 취급 안한다. 
                continue;
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
            //instantiate로 prefab을 roomListContent위치에 만들어주고 그 프리펩은 i번째 룸리스트가 된다. 
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)//다른 플레이어가 방에 들어오면 작동
    {
        Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
        //instantiate로 prefab을 playerListContent위치에 만들어주고 그 프리펩을 이름 받아서 표시. 
    }

    public void StartMultiGame()
    {
        //PhotonNetwork.LoadLevel(5);//1인 이유는 빌드에서 scene 번호가 1번씩이기 때문이다. 0은 초기 씬.
        PhotonNetwork.LoadLevel(5);//1인 이유는 빌드에서 scene 번호가 1번씩이기 때문이다. 0은 초기 씬.
    }

    public void StartGame(){
        SceneManager.LoadScene("B");
    }
}