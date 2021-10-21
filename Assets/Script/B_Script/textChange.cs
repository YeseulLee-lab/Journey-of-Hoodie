using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textChange : MonoBehaviour
{
    public string nick;
    public GameObject Destroytext;
    // Start is called before the first frame update
    void Start()
    {
        if (null == GameObject.Find("DataObject")){
            nick = "아이스";
        }
        else{
            nick = GameObject.Find("DataObject").GetComponent<TransData>().icenickname;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("SaveManager").GetComponent<Bpercent>().state == true){
            Destroytext.transform.Find("Text").gameObject.GetComponent<Text>().text = nick + " 세뇌 중";
        }
        else{
            Destroytext.transform.Find("Text").gameObject.GetComponent<Text>().text = nick + " 세뇌 실패!";
        }
       /* if(nick == "아이스 플레이어"){
            subtitleClip.subtitleText = "우아아";
        }
        else{
            subtitleClip.subtitleText = "이 더러운" + "몸을 멋대로 움직여주겠어!";
        }*/
    }
}