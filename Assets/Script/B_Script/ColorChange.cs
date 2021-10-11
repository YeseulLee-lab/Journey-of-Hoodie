using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorChange : MonoBehaviour
{
    public Material icecolorChoco;
    public Material icecolorMint;
    public string icekind;
    // Start is called before the first frame update
    void Start()
    {
        if(null != GameObject.Find("DataObject")){
            icekind = GameObject.Find("DataObject").GetComponent<TransData>().icekind;
        }
        else if(null != GameObject.Find("icenicknameObject")){
            icekind = GameObject.Find("icenicknameObject").GetComponent<nicknameObject>().icekind;
        }
        else{
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "B"){
            if(icekind == "Mint"){
                GameObject.Find("Player").transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorMint;
            }
            else if(icekind == "Choco"){
                GameObject.Find("Player").transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorChoco;
            }
        }
        else{
            if(icekind == "Mint"){
                GameObject.Find("Player").transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorMint;
            }
            else if(icekind == "Choco"){
                GameObject.Find("Player").transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorChoco;
            }
        }
    }
}
