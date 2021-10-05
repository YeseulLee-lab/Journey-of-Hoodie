using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public GameObject ID;
    public GameObject PW;
    public GameObject LoginPanel;
    public CameraControl CameraControl;
    public Transform NextSelect;
    private Text idString;
    private Text pwString;
    public bool success;

    
    // Start is called before the first frame update
    void Start()
    {
        idString = ID.GetComponent<Text>();
        pwString = PW.GetComponent<Text>();
        success = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown() {
        Debug.Log("clicked");
        if(idString.text == "1" && pwString.text == "1"){
            CameraControl.SetMount(NextSelect);
            LoginPanel.SetActive(false);
            success = true;
        }
        else{
            success = false;
        }
    }
}
