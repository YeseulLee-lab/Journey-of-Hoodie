using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AllSave : MonoBehaviour
{
    [SerializeField] public Bpercent B;
    public List<string> percentName = new List<string>();
    public List<float> percent = new List<float>();
    string icenickname;
    // Start is called before the first frame update
    void Start()
    {
        //B = GetComponent<Bpercent>();

        B = GameObject.Find("SaveManager").GetComponent<Bpercent>();

        percentName.Add("percent1");
        percentName.Add("percent2");
        percentName.Add("percent3");
        percentName.Add("Allpercentmid");
        percentName.Add("Allpercent");

        percent.Add(B.percent1);
        percent.Add(B.percent2);
        percent.Add(B.percent3);
        percent.Add(B.Allpercentmid);
        percent.Add(B.Allpercent);

        if(null != GameObject.Find("DataObject")){
            icenickname = GameObject.Find("DataObject").GetComponent<TransData>().icenickname;
        }
        else{
            icenickname = "아이스";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(null != GameObject.Find("DataObject")){
            if(GameObject.Find("DataObject").GetComponent<TransData>().Loadstate == true && GameObject.Find("B") != null){
                Load();
            }
        }

        if(Input.GetKeyDown(KeyCode.S)){
            Save();
        }else if(Input.GetKeyDown(KeyCode.L)){
            Load();
        }
        
    }

    public void Save()
    {
        List<PercentLoad> PercenttoLoad = new List<PercentLoad>();

        for(int i = 0; i< percentName.Count; i++)
        {
            PercentLoad p = new PercentLoad(percentName[i], percent[i]);
            PercenttoLoad.Add(p);
            
        }
        Debug.Log(PercenttoLoad.Count);
        //PercenttoLoad.ToString();
        string jsonP = customJSON.ToJson(PercenttoLoad);

        File.WriteAllText(Application.persistentDataPath + icenickname + "percent", jsonP);

        Debug.Log("percent Saving");
    }

    public void Load()
    {
        Debug.Log("percent Loading");

        List<PercentLoad> PercentToLoad = customJSON.FromJson<PercentLoad>(File.ReadAllText(Application.persistentDataPath + icenickname + "percent"));

        for(int i = 0; i < PercentToLoad.Count; i++)
        {
            percent[i] = PercentToLoad[i].percent;
            percentName[i] = PercentToLoad[i].percentName;
        }

        B.percent1 = ((int)PercentToLoad[0].percent);
        B.percent2 = ((int)PercentToLoad[1].percent);
        B.percent3 = ((int)PercentToLoad[2].percent);
        B.Allpercentmid = PercentToLoad[3].percent;
        B.Allpercent = PercentToLoad[4].percent;
    }
}

[System.Serializable]
public class PercentLoad
{
    public string percentName;
    public float percent;

    public PercentLoad(string PN, float P)
    {
        percentName = PN;
        percent = P;
    }
}