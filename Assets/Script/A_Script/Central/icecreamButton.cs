using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class icecreamButton : MonoBehaviour
{
    public GameObject nickname;
    public string iceKind;
    public GameObject Mint;
    public GameObject Choco;
    public GameObject icenicknameObject;
    public GameObject Button;
    // Start is called before the first frame update
    void Start()
    {
     //   nickname = GameObject.Find("Nickname");
        Mint = GameObject.Find("mintIcecream");
        Choco = GameObject.Find("ChocoIcecream");
        iceKind = gameObject.GetComponentInChildren<Text>().text;

        if(null != GameObject.Find("DataObject")){
            icenicknameObject = GameObject.Find("DataObject");
        }
        else{
            icenicknameObject = GameObject.Find("icenicknameObject");
        }
    }

    // Update is called once per frame
    public void OnClickConfirmButton(){
        if(null != GameObject.Find("DataObject")){
            Mint.SetActive(false);
            Choco.SetActive(false);
            nickname.SetActive(true);
            Button.SetActive(true);
            icenicknameObject.GetComponent<TransData>().icekind = iceKind;
        }
        else{
            Mint.SetActive(false);
            Choco.SetActive(false);
            //nickname.SetActive(true);
            icenicknameObject.GetComponent<nicknameObject>().icekind = iceKind;
            icenicknameObject.GetComponent<nicknameObject>().icenickname = "아이스";
            DontDestroyOnLoad(icenicknameObject);
            SceneManager.LoadScene("B");
           // SceneManager.LoadScene("MultiChoice");
        }
    }
}
