using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{
    public GameObject DeleteManager;
    public GameObject Timeline;
    public GameObject Camera;
    public GameObject CameraCheck;
    // Start is called before the first frame update
    void Start()
    {
        DeleteManager = GameObject.Find("DeleteTimeline");
        Timeline = GameObject.Find("Timeline");  
        Camera = GameObject.Find("Camera");  
        CameraCheck = GameObject.Find("CameraCheck");  
     //   TalkPanel = GameObject.Find("TalkPanel");
    }

    // Update is called once per frame
    void Update()
    {
        if (null != DeleteManager){
            if (gameObject.activeSelf == true){
                Timeline.SetActive(false);
                Camera.SetActive(false);
                CameraCheck.SetActive(false);
            }
            else{
                return;
            }
        }
        else{
            if(GameObject.Find("DataObject").GetComponent<TransData>().Loadstate == true){
                Timeline.SetActive(false);
                Camera.SetActive(false);
                CameraCheck.SetActive(false);
            }
        }
    }
}