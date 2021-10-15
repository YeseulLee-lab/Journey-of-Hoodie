using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multichoice : MonoBehaviour
{
    public GameObject DataObject;
    public GameObject Multi;
    public GameObject Player;
    public GameObject FindLoading;
    // Start is called before the first frame update
    void Start()
    {
        if(null != GameObject.Find("DataObject")){
            DataObject = GameObject.Find("DataObject");
            Multi.SetActive(false);
        }
        else{
            Multi.SetActive(true);
            return;
        }
    }
}
