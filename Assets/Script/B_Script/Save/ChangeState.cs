using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeState : MonoBehaviour
{
    public List<GameObject> pudding = new List<GameObject>();
    public int[] statenumber = new int[6];
    // Start is called before the first frame update
    void Start()
    {
        pudding.Add(GameObject.Find("PuddingLS1"));
        pudding.Add(GameObject.Find("PuddingLS2"));
        pudding.Add(GameObject.Find("Puddingspoon1"));
        pudding.Add(GameObject.Find("Puddingspoon2"));
        pudding.Add(GameObject.Find("Puddingfork1"));
        pudding.Add(GameObject.Find("Puddingfork2"));
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 6; i++){
            statenumber[i] = GameObject.Find("StateSave").GetComponent<StateSave>().statenumber[i];
        }

        for(int i = 0; i < 6; i++){
            if(null == pudding[i]){
                return;
            }
            else{
                if(statenumber[i] != 0){
                    pudding[i].SetActive(false);
                }
            }
        }
    }
}
