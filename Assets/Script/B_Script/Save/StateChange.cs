using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChange : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject StateSave;
    public int[] statenumber = new int[6];
    void Start()
    {
        StateSave = GameObject.Find("StateSave");
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 8; i++){
            statenumber[i] = GameObject.Find("StateSave").GetComponent<StateSave>().statenumber[i];
        }
    }
}
