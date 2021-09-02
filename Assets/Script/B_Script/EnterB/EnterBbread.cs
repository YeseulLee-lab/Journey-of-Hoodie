using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBbread : MonoBehaviour
{
    public GameObject DeleteTimeline;
    public GameObject breadpercent;
    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            // PlayerPrefs.DeleteKey("p_x");
            // PlayerPrefs.DeleteKey("p_y");
            // PlayerPrefs.DeleteKey("p_z");
            // PlayerPrefs.DeleteKey("TimeToLoad");
            SceneManager.LoadScene("B");
            DontDestroyOnLoad(DeleteTimeline);
            GameObject.Find("percentManager").GetComponent<Bpercent>().Allpercent = GameObject.Find("percentManager").GetComponent<Bpercent>().Allpercent - GameObject.Find("percentManager").GetComponent<Bpercent>().percent2 + GameObject.Find("Player").GetComponent<MapIcePlayer>().percent;
            GameObject.Find("percentManager").GetComponent<Bpercent>().percent2 = GameObject.Find("Player").GetComponent<MapIcePlayer>().percent;
            GameObject.Find("percentManager").GetComponent<Bpercent>().state = true;
        }
    }

}
