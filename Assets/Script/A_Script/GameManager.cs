using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject BrokenBridge;
    public TalkManager talkManager;
    public GameObject StartQuest;
    public GameObject talkPanel;
    public GameObject Question;
    public GameObject Image;
    public GameObject QuestButton;
    public Image portrait;
    public Text talkText;

    //public Text Quest;
    public GameObject scanObject;
    public bool isAction;
    public bool isSavable;
    public bool allSaved;
    public int talkIndex;

    public int SavedNPC = 0;
    public int SavedBridge = 0;

    public GameObject SelectPanel;
    public GameObject updatee;

    private static GameManager instance;

    public static GameManager MyGameManager{
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public void Update(){
        if(SavedNPC == 5){
            allSaved = true;
        }

        Scene scene = SceneManager.GetActiveScene();

        if(scene.name == "SampleScene"){
            if(BrokenBridge.activeSelf == false){
                SavedBridge = 1;
            }
            if(Input.GetButtonDown("Cancel"))
            {
                StartQuest.SetActive(false);
                QuestButton.SetActive(true);
                updatee.SetActive(false);
            }
        }
        
        if(Input.GetButtonDown("Quest"))
        {
            StartQuest.SetActive(!StartQuest.activeSelf);
            QuestButton.SetActive(!QuestButton.activeSelf);
        }

    }
    public void StartAction()       //퀘스트 창 뜨게 하는 함수
    {
        StartQuest.SetActive(true);
      //  StartQuest.GetComponentsInChildren<Text>()[1].text = StartQuest.GetComponent<Diary>().content[StartQuest.GetComponent<Diary>().num];
        QuestButton.SetActive(false);
        StartQuest.GetComponent<Diary>().state = false;
    }

    public void QuestionAction()        //말풍선 뜨게 하는 함수
    {
        Question.SetActive(true);
        Image.SetActive(true);
    }

    public void ExitAction()
    {
        StartQuest.SetActive(false);
        QuestButton.SetActive(true);
        StartQuest.GetComponent<Diary>().state = false;
    }

    public void Action(GameObject scanObj)      //대화 시스템. 대화하면 퀘스트버튼과 말풍선 버튼이 사라짐. scanObj에 player 오브젝트를 넣어서 사라지게 함
    {
            isAction = true;
            isSavable = false;
            scanObject = scanObj;
            ObjData objData = scanObject.GetComponent<ObjData>();
            Talk(objData.id, objData.isNpc);
        
            talkPanel.SetActive(isAction);

            Scene scene = SceneManager.GetActiveScene();

            if(scene.name == "SampleScene"){
                Question.SetActive(false);
            }
            //QuestButton.SetActive(false);

            /*switch(objData.id){
                case 1000:
                    GameObject.Find("Player").GetComponent<PlayerMove>().a = 3;
                    break;
                case 2000:
                    GameObject.Find("Player").GetComponent<PlayerMove>().a = 5;
                    break;
                case 3000:
                    GameObject.Find("Player").GetComponent<PlayerMove>().a = 7;
                    break;
                case 4000:
                    GameObject.Find("Player").GetComponent<PlayerMove>().a = 9;
                    break;
                case 5000:
                    GameObject.Find("Player").GetComponent<PlayerMove>().a = 11;
                    break;
            }*/
    }

    void Talk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);
        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            Scene scene = SceneManager.GetActiveScene();
            
            if(scene.name == "SampleScene"){
                QuestButton.SetActive(true);
                isSavable = true;
                GameObject.Find("Player").GetComponent<PlayerMove>().a++;
            }

            if(scene.name == "Pudding" || scene.name == "Bread" || scene.name == "Cheese")
            {
                SelectPanel.SetActive(true);
            }

            
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
