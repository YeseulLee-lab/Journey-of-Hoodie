using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionFollowCube : MonoBehaviour
{
    public Button Question;
    public Button Question2;


    // Start is called before the first frame update
    void Start()
    {
        if(null != gameObject.transform.parent)
        {
            if(gameObject.transform.parent.gameObject.name == "Player"){
                return;
            }
            else{
                if(SceneManager.GetActiveScene().name == "B"){
                        if(gameObject.transform.parent.gameObject.GetComponent<IcePlayer>().PV.IsMine){
                            Question = GameObject.Find("Canvas").transform.Find("BubbleWhiteSmall").gameObject.GetComponent<Button>();
                        }
                    }
                else if(SceneManager.GetActiveScene().name == "Pudding" || SceneManager.GetActiveScene().name == "Bread" || SceneManager.GetActiveScene().name == "Cheese"){
                    if(gameObject.transform.parent.gameObject.GetComponent<MapIcePlayer>().PV.IsMine){
                            Question = GameObject.Find("Canvas").transform.Find("BubbleWhiteSmall").gameObject.GetComponent<Button>();
                            Question2 = GameObject.Find("Canvas").transform.Find("BubbleWhiteSmall (2)").gameObject.GetComponent<Button>();
                        }
                    }
            }
        }
        else{
            return;
        }
    }
        // else{
        //     Question = GameObject.Find("Canvas").transform.Find("BubbleWhiteSmall2").gameObject.GetComponent<Button>();       
        // }

    // Update is called once per frame
    void Update()
    {
        // if(gameObject.transform.parent.gameObject.GetComponent<IcePlayer>().PV.IsMine)
        // {
        //     return;
        // }
        
        if(Question != null)
        {
            Vector3 questionPos = UnityEngine.Camera.main.WorldToScreenPoint(this.transform.position);
            Question.transform.position = questionPos;
        }
        if(Question2 != null)
        {
            Vector3 questionPos = UnityEngine.Camera.main.WorldToScreenPoint(this.transform.position);
            Question2.transform.position = questionPos;
        }
    }
}