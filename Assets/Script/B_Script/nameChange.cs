using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nameChange : MonoBehaviour
{
    public Text text;
    public string nick;
    // Start is called before the first frame update
    void Start()
    {
        nick = GameObject.Find("icenicknameObject").GetComponent<nicknameObject>().icenickname;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "이 더러운" + nick + "몸을 멋대로 움직여주겠어!";
    }
}
