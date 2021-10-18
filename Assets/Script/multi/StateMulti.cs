using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class StateMulti : MonoBehaviour
{
    public bool statebool;
    public StateSave stateSave;
   /* public int[] multistatenumber = new int[6];

    [PunRPC]
    public void StateChange(string str){
        for(int i = 0; i < 6; i++){
            multistatenumber[i] = GameObject.Find("StateSave").GetComponent<StateSave>().statenumber[i];
            }

      /*  for (int i = 0; i < 6; i++){
            if(multistatenumber[i] == 1){
                gameObject.GetComponent<StateSave>().Building[i].SetActive(false);
            }
            else{
                gameObject.GetComponent<StateSave>().Building[i].SetActive(true);
            }
        }
    }*/
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
