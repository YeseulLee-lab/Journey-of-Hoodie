using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bpercent : MonoBehaviour
{
   // public Text puddingText;
  //  public Text breadText;
//    public Text cheeseText;
  //  public Text Allpercenttext;
    public int percent1;
    public int percent2;
    public int percent3;
    public float Allpercent;
    public float Allpercentmid;
    public bool state;
    public static Bpercent Instance;
    void Awake() {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }
    void Start()
    {
        percent1 = GameObject.Find("SaveManager").GetComponent<Bpercent>().percent1;
        percent2 = GameObject.Find("SaveManager").GetComponent<Bpercent>().percent2;
        percent3 = GameObject.Find("SaveManager").GetComponent<Bpercent>().percent3;
        Allpercent = GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercent;
        Allpercentmid = GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercentmid;
        state = GameObject.Find("SaveManager").GetComponent<Bpercent>().state;
       // percent1 = 0;
       // percent2 = 0;
        //percent3 = 0;
      //  Allpercent = 0;
        //puddingText.text = percent1 + " 퍼센트";
       // breadText.text = percent2 + " 퍼센트";
        //cheeseText.text = percent3 + " 퍼센트";
        //townName = GameObject.Find("TownName").GetComponent<Text>();
      //  Allpercenttext = GameObject.Find("Text").GetComponent<Text>();
       // Allpercenttext.text = Allpercent + "%";
    }

    // Update is called once per frame
    void Update()
    {
        /*if (GameObject.Find("Player").GetComponent<IcePlayer>().hit.transform.gameObject.tag == "Building")
        {
            percent1 = GameObject.Find("percentManager").GetComponent<Bpercent>().percent1;
            puddingText.text = percent1 + "퍼센트";
        }

        if (GameObject.Find("Player").GetComponent<IcePlayer>().
            hit.transform.gameObject.tag == "Building2")
        {
            percent2 = GameObject.Find("percentManager").GetComponent<Bpercent>().percent2;
            breadText.text = percent2 + "퍼센트";
        }

        if (GameObject.Find("Player").GetComponent<IcePlayer>().
            hit.transform.gameObject.tag == "Building3")
        {
            percent3 = GameObject.Find("percentManager").GetComponent<Bpercent>().percent3;
            cheeseText.text = percent3 + "퍼센트";
        }*/

     //   if(state == true){
            //if (percent1 != 0 && percent2 != 0 && percent3 != 0){
                //Allpercentmid = Mathf.Round(GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercent/3);
                //if (Allpercentmid >= 50){
                //    print("세뇌 풀래 말래");
               // }
          //      state = false;
           // }
            //else if((percent1 != 0 && percent2 != 0) || (percent1 != 0 && percent3 != 0) || (percent2 != 0 && percent3 != 0)){
               // Allpercentmid = Mathf.Round(GameObject.Find("percentManager").GetComponent<Bpercent>().Allpercent/3);
               // state = false;
          //  }
           // else{
             //   Allpercentmid = Mathf.Round(GameObject.Find("percentManager").GetComponent<Bpercent>().Allpercent)/3;
              //  state = false;
            //}
        }
    }