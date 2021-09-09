using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateSave : MonoBehaviour
{
    public List<GameObject> pudding = new List<GameObject>();
    public int[] statenumber = new int[6];
    public GameObject SaveManager;
    //List<int> statenumber = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        SaveManager = GameObject.Find("SaveManager");

        for (int i = 0; i < 6; i++){
            statenumber[i] = SaveManager.GetComponent<ChangeState>().statenumber[i];
        }

        pudding.Add(GameObject.Find("Puddingfork1"));
        pudding.Add(GameObject.Find("Puddingfork2"));
        pudding.Add(GameObject.Find("Puddingspoon1"));
        pudding.Add(GameObject.Find("Puddingspoon2"));
        pudding.Add(GameObject.Find("PuddingLS1"));
        pudding.Add(GameObject.Find("PuddingLS2"));
        //pudding = GameObject.FindGameObjectsWithTag("Building2");
        //pudding = GameObject.FindGameObjectsWithTag("Building3");
    }

    // Update is called once per frame
    void Update()
    {
       /* if (null != SaveManager){
            for (int i = 0; i < 6; i++){
                statenumber[i] = SaveManager.GetComponent<ChangeState>().statenumber[i];
            }
        }
        else
        {*/
            for (int i = 0; i < 6; i++){
                if(null == pudding[i]){
                    return;
                }
                else{
                    if (pudding[i].activeSelf == false){
                        statenumber[i] = 1;
                    }
                    else{
                        statenumber[i] = 0;
                    }
                }
            }
     //  }
    }
}
