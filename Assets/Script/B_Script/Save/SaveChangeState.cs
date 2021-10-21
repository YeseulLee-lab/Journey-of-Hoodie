using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveChangeState : MonoBehaviour
{
    [SerializeField] public StateSave changeState;
    [SerializeField] public StateMulti StateMulti;
    string icenickname;
    //public List<int> stateNum = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        changeState = GameObject.Find("StateSave").GetComponent<StateSave>();
        StateMulti = GameObject.Find("StateSave").GetComponent<StateMulti>();

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
      //  if(SceneManager.GetActiveScene().name == "Pudding"){
            if(Input.GetKeyDown(KeyCode.S))
            {
                Save();
            }else if(Input.GetKeyDown(KeyCode.L)){
                Load();
            }
     //   }
    }

    public void Save()
    {
        List<StateLoad> StateToLoad = new List<StateLoad>();

        for(int i = 0; i< changeState.statenumber.Length; i++)
        {
            StateLoad s = new StateLoad(changeState.statenumber[i]);
            StateToLoad.Add(s);
        }

        string jsonS = customJSON.ToJson(StateToLoad);

        if(SceneManager.GetActiveScene().name == "Pudding"){
            File.WriteAllText(Application.persistentDataPath + icenickname + "puddingstate", jsonS);
        }
        else if(SceneManager.GetActiveScene().name == "Bread"){
            File.WriteAllText(Application.persistentDataPath + icenickname + "breadstate", jsonS);
        }
        else if(SceneManager.GetActiveScene().name == "Cheese"){
            File.WriteAllText(Application.persistentDataPath + icenickname + "cheesestate", jsonS);
        }

        Debug.Log("State Saving..");
    }

    public void Load()
    {
        Debug.Log("State Loading..");

        List<StateLoad> StateToLoad = new List<StateLoad>();

        if(SceneManager.GetActiveScene().name == "Pudding"){
            StateToLoad = customJSON.FromJson<StateLoad>(File.ReadAllText(Application.persistentDataPath + icenickname + "puddingstate"));
        }
        else if(SceneManager.GetActiveScene().name == "Bread"){
            StateToLoad = customJSON.FromJson<StateLoad>(File.ReadAllText(Application.persistentDataPath + icenickname + "breadstate"));
        }
        else if(SceneManager.GetActiveScene().name == "Cheese"){
            StateToLoad = customJSON.FromJson<StateLoad>(File.ReadAllText(Application.persistentDataPath + icenickname + "cheesestate"));
        }

        for(int i = 0; i < StateToLoad.Count; i++)
        {
            //Debug.Log(StateToLoad[i].stateNum);
            changeState.statenumber[i] = StateToLoad[i].stateNum;
           // StateMulti.multistatenumber[i] = StateToLoad[i].stateNum;

            //Debug.Log(changeState.statenumber[i]);
        }
    }
    
}

[System.Serializable]

public class StateLoad
{
    public int stateNum;

    public StateLoad(int SN)
    {
        stateNum = SN;
    }
    
}
