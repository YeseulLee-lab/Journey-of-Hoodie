using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransData : MonoBehaviour
{
    public string nickname;
    public GameObject DataObject;
    public void call()
    {
        SceneManager.LoadScene("SampleScene");
        DontDestroyOnLoad(DataObject);
    }
}
