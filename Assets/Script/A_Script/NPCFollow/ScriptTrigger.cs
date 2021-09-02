using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public Text talkText;
    public GameObject talkPanel;
    //public TalkManager talkManager;
    public Image portrait;

    public TalkManager talkManager;

    //public Text Quest;
    public int talkIndex;

    public int SavedNPC = 0;
    public GameManager manager;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
          Action(other);
        }
    }

    public void Action(Collider scanObj)      //대화 시스템. 대화하면 퀘스트버튼과 말풍선 버튼이 사라짐. scanObj에 player 오브젝트를 넣어서 사라지게 함
    {
            ObjData objData = scanObj.GetComponent<ObjData>();
            Talk(objData.id, objData.isNpc);
        
            talkPanel.SetActive(true);
            //Question.SetActive(false);
            //QuestButton.SetActive(false);
    }

    void Talk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);
        if(talkData == null)
        {
            talkIndex = 0;
           // QuestButton.SetActive(true);
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
        talkIndex++;
    }
}
