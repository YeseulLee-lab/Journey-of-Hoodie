using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBcheese : MonoBehaviour
{
    public GameObject DeleteTimeline;
    public GameObject cheesepercent;
    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            // PlayerPrefs.DeleteKey("p_x");
            // PlayerPrefs.DeleteKey("p_y");
            // PlayerPrefs.DeleteKey("p_z");
            // PlayerPrefs.DeleteKey("TimeToLoad");
            GameObject.FindWithTag("Player").GetComponent<SaveAndLoad>().Save();
            GameObject.FindWithTag("Player").GetComponent<SaveChangeState>().Save();
            SceneManager.LoadScene("B");
            DontDestroyOnLoad(DeleteTimeline);
            GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercent = GameObject.Find("Player").GetComponent<MapIcePlayer>().Allpercent;// - GameObject.Find("SaveManager").GetComponent<Bpercent>().percent3 + GameObject.Find("Player").GetComponent<MapIcePlayer>().percent;
            GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercentmid = GameObject.Find("Player").GetComponent<MapIcePlayer>().Allpercentmid;
            GameObject.Find("SaveManager").GetComponent<Bpercent>().percent3 = GameObject.Find("Player").GetComponent<MapIcePlayer>().percent;
        }
    }
}