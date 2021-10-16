using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionFollowCube : MonoBehaviour
{
    public Button Question;


    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.transform.parent.gameObject.GetComponent<IcePlayer>().PV.IsMine){
            Question = GameObject.Find("Canvas").transform.Find("BubbleWhiteSmall").gameObject.GetComponent<Button>();
        }
        // else{
        //     Question = GameObject.Find("Canvas").transform.Find("BubbleWhiteSmall2").gameObject.GetComponent<Button>();       
        // }
    }

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
        
    }
}
