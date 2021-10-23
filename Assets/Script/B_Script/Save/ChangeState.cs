using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 필요없음
public class ChangeState : MonoBehaviour
{
    public GameObject StateSave;
  //  public List<GameObject> Building = new List<GameObject>();
    public int[] statenumber = new int[6];
    // Start is called before the first frame update
    void Start()
    {
       // StateSave = GameObject.Find("StateSave");

       /* Building.Add(GameObject.Find("BuildingLS1"));
        Building.Add(GameObject.Find("BuildingLS2"));
        Building.Add(GameObject.Find("Buildingspoon1"));
        Building.Add(GameObject.Find("Buildingspoon2"));
        Building.Add(GameObject.Find("Buildingfork1"));
        Building.Add(GameObject.Find("Buildingfork2"));*/
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
                if(null == GameObject.Find("StateSave").GetComponent<StateSave>().Building[i]){
                    return;
                }
                else{
                    if(statenumber[i] != 0){
                        GameObject.Find("StateSave").GetComponent<StateSave>().Building[i].SetActive(false);
                        GameObject.Find("StateSave").GetComponent<StateSave>().Wreck[i].SetActive(true);
                    }
                }
            }
        }
    }
}