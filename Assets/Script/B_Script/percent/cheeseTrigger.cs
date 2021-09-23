using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cheeseTrigger : MonoBehaviour
{
    public Text cheeseText;
    // Start is called before the first frame update
    void Start()
    {
        cheeseText.text = 0 + " 퍼센트";
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player"){
            //percent3 = GameObject.Find("percentManager").GetComponent<Bpercent>().percent3;
            cheeseText.text = GameObject.Find("SaveManager").GetComponent<Bpercent>().percent3 + "퍼센트";
        }        
    }
}
