using System.Collections;
using System.Collections.Generic;
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
        Loadstate = true;
        SceneManager.LoadScene("B");
        DontDestroyOnLoad(DataObject);
    }
}