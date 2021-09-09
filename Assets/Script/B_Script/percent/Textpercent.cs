using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textpercent : MonoBehaviour
{
    //public GameObject percentManager;
    public Text Allpercenttext;
    // Start is called before the first frame update
    void Start()
    {
        Allpercenttext = GameObject.Find("percentText").GetComponent<Text>();
        Allpercenttext.text = 0 + "%";
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercentmid != 0){
            Allpercenttext.text = GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercentmid + "%";
        }
    }
}
