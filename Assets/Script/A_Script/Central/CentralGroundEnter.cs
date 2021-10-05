using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CentralGroundEnter : MonoBehaviour
{
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
            if (Input.GetKeyDown(KeyCode.Space)){
                AlertPanel.SetActive(false);
            }
        }  
    }

    void OnTriggerEnter(Collider col){
        if(GameManager.MyGameManager.SavedNPC >= 5){
            Destroy(gameObject);
            Destroy(Collider);
        }else{
            AlertPanel.SetActive(true);
            QuestText.text = "모두를 먼저 구해야 합니다!";
        }
    }
}
