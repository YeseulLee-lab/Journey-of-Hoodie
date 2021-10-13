using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoomListItem : MonoBehaviour
{
    public TMP_Text FindRoomNametext;
    RoomInfo info;
    // Start is called before the first frame update
    public void SetUp(RoomInfo _info){
        info = _info;
        FindRoomNametext.text = _info.Name;
    }

    public void Onclick(){
        GameObject.Find("Photon").GetComponent<Launcher>().JoinRoom(info);
        Debug.Log("loading...");
    }

}
