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
        Allpercenttext.text = "B행성 침략 중 " + 0 + "%";
    }

    // Update is called once per frame
    void Update()
    {
       // if (GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercentmid != 0){
            if(GameObject.Find("SaveManager").GetComponent<Bpercent>().state == true){
                Allpercenttext.text = "B행성 침략 중 " + GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercent + "%";
            }
            else{
                Allpercenttext.text = "B행성 복구 중 " + GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercent + "%";
            }
      //  }
    }
}
