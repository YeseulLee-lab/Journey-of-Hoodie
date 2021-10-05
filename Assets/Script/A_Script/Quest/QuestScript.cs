using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuestScript : MonoBehaviour
{
    public Quest MyQuest { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        EventSystem.current.SetSelectedGameObject(GameObject.Find("QuestText(Clone)"));
        //Debug.Log(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select()
    {
        GetComponent<Text>().color = Color.red;
        QuestLog.MyInstance.ShowDescription(MyQuest);
    }

    public void DeSelect()
    {
        GetComponent<Text>().color = Color.white;
    }
}
