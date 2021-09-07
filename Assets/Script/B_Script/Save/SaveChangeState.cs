using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveChangeState : MonoBehaviour
{
    ChangeState changeState;
    //public List<int> stateNum = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        changeState = GameObject.Find("StateSave").GetComponent<ChangeState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }else if(Input.GetKeyDown(KeyCode.L)){
            Load();
        }
    }

    void Save()
    {
        List<StateLoad> StateToLoad = new List<StateLoad>();

        for(int i = 0; i< changeState.statenumber.Length; i++)
        {
            StateLoad s = new StateLoad(changeState.statenumber[i]);
            StateToLoad.Add(s);
        }

        string jsonS = customJSON.ToJson(StateToLoad);

        File.WriteAllText(Application.persistentDataPath + transform.name + "state", jsonS);

        Debug.Log("State Saving..");
    }

    void Load()
    {
        Debug.Log("State Loading..");
        
        List<StateLoad> StateToLoad = customJSON.FromJson<StateLoad>(File.ReadAllText(Application.persistentDataPath + transform.name + "state"));

        for(int i = 0; i < StateToLoad.Count; i++)
        {
            //Debug.Log(StateToLoad[i].stateNum);
            changeState.statenumber[i] = StateToLoad[i].stateNum;
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
