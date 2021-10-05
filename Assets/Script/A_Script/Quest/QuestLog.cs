using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLog : MonoBehaviour
{
    [SerializeField]
    private GameObject questPrefab;

    [SerializeField]
    private Transform questParent;

    private Quest selected;
    private QuestGiver questGiver;

    [SerializeField]
    private Text questDescription;

    private static QuestLog instance;

    string title;

    public CollectObjective collectObjective;

    public static QuestLog MyInstance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<QuestLog>();
            }
            return instance;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AcceptQuest(Quest quest)
    {
        GameObject go = Instantiate(questPrefab, questParent);

        QuestScript qs = go.GetComponent<QuestScript>();
        quest.MyQuestScript = qs;
        qs.MyQuest = quest;

       // print(quest.title);
        go.GetComponent<Text>().text = quest.title;
      //  qs.MyQuest.title = quest.title; // go.GetComponent<Text>().text;
        
    }

    public void UpdateSelected(Quest quest){
        ShowDescription(quest);
    }

    public void ShowDescription(Quest quest)
    {
        if(selected != null)
        {
            selected.MyQuestScript.DeSelect();
        }

        string objectives = string.Empty;
        selected = quest;

        title = quest.title;

        foreach (Objective obj in quest.MyCollectObjectives)
        {
            if(obj.MyType == "동료"){
                objectives += obj.MyType + ": " + GameManager.MyGameManager.SavedNPC + "/" + obj.MyAmount + "\n";
            }else{
                objectives += obj.MyType + ": " + GameManager.MyGameManager.SavedBridge + "/" + obj.MyAmount + "\n";
            }
        }

        questDescription.text = string.Format("<b>{0}</b> \n <size=20>{1}</size><b>\n\n목표\n</b><size=20>{2}</size>", title, quest.MyDescription, objectives);
    }
    
}
