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
    // Start is called before the first frame update
    void Start()
    {
     //   nickname = GameObject.Find("Nickname");
        Mint = GameObject.Find("mintIcecream");
        Choco = GameObject.Find("ChocoIcecream");
        iceKind = gameObject.GetComponentInChildren<Text>().text;

        icenicknameObject = GameObject.Find("DataObject");
    }

    // Update is called once per frame
    public void OnClickConfirmButton(){
        if(null != GameObject.Find("DataObject")){
            Mint.SetActive(false);
            Choco.SetActive(false);
            nickname.SetActive(true);
            icenicknameObject.GetComponent<TransData>().icekind = iceKind;
        }
        else{
            Mint.SetActive(false);
            Choco.SetActive(false);
            //nickname.SetActive(true);
            icenicknameObject.GetComponent<TransData>().icekind = iceKind;
            icenicknameObject.GetComponent<TransData>().icenickname = "아이스";
            DontDestroyOnLoad(icenicknameObject);
            SceneManager.LoadScene("B");
        }
    }
}
