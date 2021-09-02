using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nicknameObject : MonoBehaviour
{
    public string icenickname;
    public string icekind;
    public GameObject Nickname;
    // Start is called before the first frame update
    void Start()
    {
      //  GameObject.Find("Canvas").transform.FindChild("Nickname").gameObject.SetActive(true);
        Nickname = GameObject.Find("Canvas").transform.Find("Nickname").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Nickname.activeSelf == false){
            return;
        }
        else{
            icenickname = GameObject.Find("Nickname").GetComponent<nicknameAdd>().icenickname;
        }
    }
}
