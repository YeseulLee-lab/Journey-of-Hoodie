using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TriggertoSave : MonoBehaviour
{
    public TriggerManager triggerManager;
    public Text QuestText;
    public GameObject AlertPanel;

    public GameObject Collider;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(AlertPanel.activeSelf == true){
            if (Input.GetButtonDown("Enter")){
                AlertPanel.SetActive(false);
            }
        }  
    }

    void OnTriggerEnter(Collider col){
        GameObject [] Trigger = triggerManager.Trigger;

        if(col.gameObject.tag == "Player"){
            //Debug.Log(gameObject.name);
            if(gameObject == Trigger[triggerManager.index]){
                Collider.GetComponent<Collider>().isTrigger = true;
                Debug.Log(gameObject.name);
                Destroy(gameObject);
                Destroy(Collider);
                triggerManager.index ++;
            }else{
                Collider.GetComponent<Collider>().isTrigger = false;
                AlertPanel.SetActive(true);
                QuestText.text = triggerManager.GetName(Trigger[triggerManager.index]) + "(을)를 먼저 구해야 합니다!";
            }
        }

    }
}
