using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class breadTrigger : MonoBehaviour
{
    public Text breadText;
    // Start is called before the first frame update
    void Start()
    {
        breadText.text = 0 + " 퍼센트";
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player"){
            //percent2 = GameObject.Find("percentManager").GetComponent<Bpercent>().percent2;
            breadText.text = GameObject.Find("SaveManager").GetComponent<Bpercent>().percent2 + "퍼센트";
        }        
    }
}
