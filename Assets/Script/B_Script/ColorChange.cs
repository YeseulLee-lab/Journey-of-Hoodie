using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Material icecolorChoco;
    public Material icecolorMint;
    public string icekind;
    // Start is called before the first frame update
    void Start()
    {
        icekind = GameObject.Find("icenicknameObject").GetComponent<nicknameObject>().icekind;

        if(icekind == "Mint"){
            GameObject.Find("Player").transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorMint;
        }
        else if(icekind == "Choco"){
            GameObject.Find("Player").transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorChoco;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
