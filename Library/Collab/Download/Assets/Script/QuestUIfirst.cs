using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUIfirst : MonoBehaviour
{
    public GameObject text1;
    public GameObject button1;
    int i;

    void open(){
        text1.gameObject.SetActive(true);
        button1.gameObject.SetActive(true);
        i++;
    }
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (i == 0){
            if(gameObject.activeSelf == true){
            Invoke("open", 1);
            }
        }
    }
}
