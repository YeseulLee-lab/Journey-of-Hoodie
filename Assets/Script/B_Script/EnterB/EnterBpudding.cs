using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBpudding : MonoBehaviour
{
    public GameObject DeleteTimeline;
    public GameObject puddingpercent;
    public GameObject StateSave;
    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            // PlayerPrefs.DeleteKey("p_x");
            // PlayerPrefs.DeleteKey("p_y");
            // PlayerPrefs.DeleteKey("p_z");
            // PlayerPrefs.DeleteKey("TimeToLoad");
            GameObject.Find("Player").GetComponent<SaveAndLoad>().Save();
            GameObject.Find("Player").GetComponent<SaveChangeState>().Save();
            SceneManager.LoadScene("B");
            DontDestroyOnLoad(DeleteTimeline);
            GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercent = GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercent - GameObject.Find("SaveManager").GetComponent<Bpercent>().percent1 + GameObject.Find("Player").GetComponent<MapIcePlayer>().percent;   
            GameObject.Find("SaveManager").GetComponent<Bpercent>().percent1 = GameObject.Find("Player").GetComponent<MapIcePlayer>().percent;
            GameObject.Find("SaveManager").GetComponent<Bpercent>().state = true;
        }
    }

}
