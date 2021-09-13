using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeState : MonoBehaviour
{
    public GameObject StateSave;
    public List<GameObject> pudding = new List<GameObject>();
    public int[] statenumber = new int[6];
    // Start is called before the first frame update
    void Start()
    {
       // StateSave = GameObject.Find("StateSave");

       /* pudding.Add(GameObject.Find("PuddingLS1"));
        pudding.Add(GameObject.Find("PuddingLS2"));
        pudding.Add(GameObject.Find("Puddingspoon1"));
        pudding.Add(GameObject.Find("Puddingspoon2"));
        pudding.Add(GameObject.Find("Puddingfork1"));
        pudding.Add(GameObject.Find("Puddingfork2"));*/
    }

    // Update is called once per frame
    void Update()
    {
        StateSave = GameObject.Find("StateSave");

        if (null != StateSave){
            for(int i = 0; i < 6; i++){
                GameObject.Find("StateSave").GetComponent<StateSave>().statenumber[i] = statenumber[i];
            }

            for(int i = 0; i < 6; i++){
                if(null == GameObject.Find("StateSave").GetComponent<StateSave>().pudding[i]){
                    return;
                }
                else{
                    if(statenumber[i] != 0){
                        GameObject.Find("StateSave").GetComponent<StateSave>().pudding[i].SetActive(false);
                    }
                }
            }
        }
    }
}
