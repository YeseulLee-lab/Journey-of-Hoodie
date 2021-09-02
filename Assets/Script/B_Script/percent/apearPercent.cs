using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apearPercent : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Timeline;
    public GameObject Destroytext;
    public GameObject Percent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.activeSelf == false){
            Destroytext.SetActive(true);
            Percent.SetActive(true);
        }
    }
}
