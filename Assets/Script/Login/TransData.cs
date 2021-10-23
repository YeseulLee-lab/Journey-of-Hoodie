using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransData : MonoBehaviour
{
    public string nickname;
    public string icenickname;
    public string icekind;
    public GameObject DataObject;
    [SerializeField] public GameObject New;
    [SerializeField] public GameObject Load;
    [SerializeField] public GameObject warning;
    public bool Loadstate;
    public void call()
    {
        New.SetActive(true);
        Load.SetActive(true);
    }

    public void OnClickConfirmNew(){
        Loadstate = false;
        SceneManager.LoadScene("SampleScene");
        DontDestroyOnLoad(DataObject);
    }

    public void OnClickConfirmLoad(){
        if(GameObject.Find("Data").GetComponent<FindData>().file.Contains(icenickname + "percent")){
            Loadstate = true;
            SceneManager.LoadScene("B");
            DontDestroyOnLoad(DataObject);
        }
        else{
            warning.SetActive(true);
        }
        /*for(int i = 0; i < GameObject.Find("Data").GetComponent<FindData>().file.Count; i++){
            if((GameObject.Find("Data").GetComponent<FindData>().file[i] == (icenickname + "percent"))){ // || (GameObject.Find("Data").GetComponent<FindData>().file[i] != (icenickname + "color"))){
                Loadstate = true;
                SceneManager.LoadScene("B");
                DontDestroyOnLoad(DataObject);
                return;
            }
            else{
                print("경고창");
            }
        }*/
    }
}