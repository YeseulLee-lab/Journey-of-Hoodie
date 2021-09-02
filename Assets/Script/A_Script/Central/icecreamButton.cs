using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class icecreamButton : MonoBehaviour
{
    public GameObject nickname;
    public string iceKind;
    public GameObject Mint;
    public GameObject Choco;
    // Start is called before the first frame update
    void Start()
    {
     //   nickname = GameObject.Find("Nickname");
        Mint = GameObject.Find("mintIcecream");
        Choco = GameObject.Find("ChocoIcecream");
        iceKind = gameObject.GetComponentInChildren<Text>().text;
    }

    // Update is called once per frame
    public void OnClickConfirmButton(){
        Mint.SetActive(false);
        Choco.SetActive(false);
        nickname.SetActive(true);
        GameObject.Find("icenicknameObject").GetComponent<nicknameObject>().icekind = iceKind;
    }
}
