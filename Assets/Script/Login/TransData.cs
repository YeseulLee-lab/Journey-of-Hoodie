using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransData : MonoBehaviour
{
    public string nickname;
    public string icenickname;
    public GameObject DataObject;
    public GameObject New;
    public GameObject Load;
    public void call()
    {
        New.SetActive(true);
        Load.SetActive(true);
    }

    public void OnClickConfirmNew(){
        SceneManager.LoadScene("SampleScene");
        DontDestroyOnLoad(DataObject);
    }

    public void OnClickConfirmLoad(){
        SceneManager.LoadScene("B");
        DontDestroyOnLoad(DataObject);
    }
}