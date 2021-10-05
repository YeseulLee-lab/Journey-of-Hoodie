using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject StartQuest;
    public GameObject talkPanel;
    public GameObject Question;
    public GameObject QuestionClick;
    public Image portrait;
    public Text talkText;
    public Image Questionimage;
    public Image QuestionClickimage;
    public Image Questimage;
    public Text Quest;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

    public void StartAction()
    {
        Question.SetActive(false);
        StartQuest.SetActive(true);
    }
    public void QuestionAction()
    {
        Question.SetActive(true);
    }

    public void Action(GameObject scanObj)
    {
    
            isAction = true;
            scanObject = scanObj;
            ObjData objData = scanObject.GetComponent<ObjData>();
            Talk(objData.id, objData.isNpc);
        

             talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc)
    {

        string talkData = talkManager.GetTalk(id, talkIndex);
        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }
        if (isNpc)
        {
            talkText.text = talkData.Split(':')[0];

            portrait.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portrait.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.text = talkData;
            portrait.color = new Color(1, 1, 1, 0);
        }
        isAction = true;
        talkIndex++;
    }
}
