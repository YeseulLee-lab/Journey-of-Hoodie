using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puddingTrigger : MonoBehaviour
{
    public Text puddingText;
    // Start is called before the first frame update
    void Start()
    {
        puddingText.text = 0 + " 퍼센트";
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player"){
           // percent1 = GameObject.Find("percentManager").GetComponent<Bpercent>().percent1;
            puddingText.text = GameObject.Find("SaveManager").GetComponent<Bpercent>().percent1 + "퍼센트";
        }
    }
}
