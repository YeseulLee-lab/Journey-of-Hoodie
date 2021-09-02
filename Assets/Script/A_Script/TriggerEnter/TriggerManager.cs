using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public GameObject currentObjective;
    public GameObject [] Trigger;
    Dictionary<string, GameObject> TriggerData;
    public int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentObjective = Trigger[index];
        TriggerData = new Dictionary<string, GameObject>();
        GenerateData();
    }

    void GenerateData(){
        TriggerData.Add("도뮈뉙", Trigger[0]);
        TriggerData.Add("뷔앙카", Trigger[1]);
        TriggerData.Add("제쉬카", Trigger[2]);
        TriggerData.Add("쉬드", Trigger[3]);
        TriggerData.Add("올뤼뷔아", Trigger[4]);
    }

    public string GetName(GameObject trigger){
        if(trigger == TriggerData["도뮈뉙"]){
            return "도뮈닉";
        }else if(trigger == TriggerData["뷔앙카"]){
            return "뷔앙카";
        }else if(trigger == TriggerData["제쉬카"]){
            return "제쉬카";
        }else if(trigger == TriggerData["쉬드"]){
            return "쉬드";
        }else {
            return "올뤼뷔아";
        }
    }

    // Update is called once per frame
    /*public void OnTriggerEnter(Collider Player)
    {
        foreach(GameObject value in TriggerData.Values){
            if(currentObjective == value){
                Debug.Log(value);
            }
        }
    }*/
}
