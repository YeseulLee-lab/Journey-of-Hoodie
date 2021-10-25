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
            if(null != MultiPlayer[0].GetComponent<MapIcePlayer>().PV){
                MultiPlayer[0].GetComponent<MapIcePlayer>().PV.RPC("EnterB", Photon.Pun.RpcTarget.Others, "B");
            }            
            SceneManager.LoadScene("B");
            DontDestroyOnLoad(DeleteTimeline);
            DontDestroyOnLoad(GameObject.Find("Cheese"));
            GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercent = MultiPlayer[0].GetComponent<MapIcePlayer>().Allpercent;// - GameObject.Find("SaveManager").GetComponent<Bpercent>().percent3 + GameObject.Find("Player").GetComponent<MapIcePlayer>().percent;
            GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercentmid = MultiPlayer[0].GetComponent<MapIcePlayer>().Allpercentmid;
            GameObject.Find("SaveManager").GetComponent<Bpercent>().percent3 = MultiPlayer[0].GetComponent<MapIcePlayer>().percent;
            MultiPlayer[1].GetComponent<MapIcePlayer>().PV.RPC("BpercentSyncc", Photon.Pun.RpcTarget.All, MultiPlayer[0].GetComponent<MapIcePlayer>().Allpercent, MultiPlayer[0].GetComponent<MapIcePlayer>().Allpercentmid, MultiPlayer[0].GetComponent<MapIcePlayer>().percent);
        }
    }
}