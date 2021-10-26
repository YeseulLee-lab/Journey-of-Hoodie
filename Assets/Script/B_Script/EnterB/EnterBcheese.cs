using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBcheese : MonoBehaviour
{
    public GameObject DeleteTimeline;
    public GameObject cheesepercent;
    public GameObject[] MultiPlayer;
    void Update() {
        MultiPlayer = GameObject.FindGameObjectsWithTag("Player");
    }
    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            // PlayerPrefs.DeleteKey("p_x");
            // PlayerPrefs.DeleteKey("p_y");
            // PlayerPrefs.DeleteKey("p_z");
            // PlayerPrefs.DeleteKey("TimeToLoad");
            GameObject.FindWithTag("Player").GetComponent<SaveAndLoad>().Save();
            GameObject.FindWithTag("Player").GetComponent<SaveChangeState>().Save();
            if(null != col.GetComponent<MapIcePlayer>().PV){
                col.GetComponent<MapIcePlayer>().PV.RPC("EnterB", Photon.Pun.RpcTarget.OthersBuffered, "B");
                col.GetComponent<MapIcePlayer>().PV.RPC("BAllpercentSync", Photon.Pun.RpcTarget.OthersBuffered, col.GetComponent<MapIcePlayer>().Allpercent);
                col.GetComponent<MapIcePlayer>().PV.RPC("BAllpercentmidSync", Photon.Pun.RpcTarget.OthersBuffered, col.GetComponent<MapIcePlayer>().Allpercentmid);
                col.GetComponent<MapIcePlayer>().PV.RPC("BpercentSyncc", Photon.Pun.RpcTarget.OthersBuffered, col.GetComponent<MapIcePlayer>().percent);
            }            
            SceneManager.LoadScene("B");
            DontDestroyOnLoad(DeleteTimeline);
            GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercent = col.GetComponent<MapIcePlayer>().Allpercent;// - GameObject.Find("SaveManager").GetComponent<Bpercent>().percent3 + GameObject.Find("Player").GetComponent<MapIcePlayer>().percent;
            GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercentmid = col.GetComponent<MapIcePlayer>().Allpercentmid;
            GameObject.Find("SaveManager").GetComponent<Bpercent>().percent3 = col.GetComponent<MapIcePlayer>().percent;
        }
    }
}