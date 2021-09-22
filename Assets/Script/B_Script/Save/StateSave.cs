using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateSave : MonoBehaviour
{
   // [SerializeField]
    public GameObject[] Building;
    //public GameObject[][] Building;
   // public List<GameObject> Building = new List<GameObject>();
    public int[] statenumber = new int[6];
    public GameObject SaveManager;
    //List<int> statenumber = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
      //  SaveManager = GameObject.Find("SaveManager");

        /*Building.Add(GameObject.Find("Puddingfork1"));
        Building.Add(GameObject.Find("Puddingfork2"));
        Building.Add(GameObject.Find("Puddingspoon1"));
        Building.Add(GameObject.Find("Puddingspoon2"));
        Building.Add(GameObject.Find("PuddingLS1"));
        Building.Add(GameObject.Find("PuddingLS2"));*/
        //Building.Add(GameObject.FindGameObjectsWithTag("Building"));

       // for (int i = 0; i < 6; i++){
      //      statenumber[i] = SaveManager.GetComponent<ChangeState>().statenumber[i];
     //   }
     //   Building[0] = GameObject.FindGameObjectsWithTag("Building");
     //   Building[1] = GameObject.FindGameObjectsWithTag("Building2");
      //  Building[2] = GameObject.FindGameObjectsWithTag("Building3");
    }

    // Update is called once per frame
    void Update()
    {
       // print(Building[0][1]);
        for (int i = 0; i < 8; i++){
            if(statenumber[i] == 1){
                Building[i].SetActive(false);
            }
            else{
                Building[i].SetActive(true);
            }
    }
       /* if (null != SaveManager){
            for (int i = 0; i < 6; i++){
                statenumber[i] = SaveManager.GetComponent<ChangeState>().statenumber[i];
            }
        }
        else
        {*/
           /* for (int i = 0; i < 6; i++){
                if(null == Building[i]){
                    return;
                }
                else if(statenumber[i] == 1){
                    return;
                }
                else{
                    if (Building[i].activeSelf == false){
                        statenumber[i] = 1;
                    }
                    else{
                        statenumber[i] = 0;
                    }
                }
            }
     //  }*/
    }
}
