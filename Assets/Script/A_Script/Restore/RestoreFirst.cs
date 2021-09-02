using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreFirst : MonoBehaviour
{
    RaycastHit hit;
    float MaxDistance = 15f;
    private GameObject scanObject;
    public GameManager gameManager;
    private Transform PlayerTrans;
    public GameObject Restored;
    public GameObject PressSpace;
    public GameObject DustExplosion;
    private Quest quest;
    //public GameObject house;
    // Start is called before the first frame update
    public bool isSaved;
    void Start()
    {
        PlayerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        isSaved = false;
        //quest = QuestLog.MyInstance.selected;
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Physics.Raycast(PlayerTrans.position + PlayerTrans.up * 0.75f, PlayerTrans.forward, out hit, MaxDistance))
                {
                    scanObject = hit.transform.gameObject;  
                    if(scanObject == gameObject){
                        gameObject.SetActive(false);
                        Restored.SetActive(true);
                        isSaved = true;
                        gameManager.SavedNPC ++;
                        if(scanObject.name == "Rock"){
                            gameManager.SavedNPC --;
                        }
                        Instantiate(DustExplosion, transform.position, transform.rotation);
                        Debug.Log("제발ㅃ더랑");
                        //QuestLog.MyInstance.ShowDescription(quest);
                    }
                }
            }
            if(Vector3.Distance(PlayerTrans.position, transform.position) <= 20.0f){
                //Instantiate(PressSpace);
                PressSpace.SetActive(true);
            }else{
                //Instantiate(PressSpace);
                PressSpace.SetActive(false);
            }

            if(isSaved == true){
                //Instantiate(PressSpace);
                PressSpace.SetActive(false);
            }
        
    }

}
