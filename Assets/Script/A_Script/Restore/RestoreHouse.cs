using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreHouse : MonoBehaviour
{
    RaycastHit hit;
    float MaxDistance = 15f;
    private GameObject scanObject;
    public GameManager gameManager;
    private Transform PlayerTrans;

    public GameObject Restored;
    public GameObject savedNPC;
    public GameObject NPC;
    public GameObject PressE;
    public GameObject PressSpace;
    private Quest quest;

    public GameObject DustExplosion;
    //public GameObject house;
    // Start is called before the first frame update
    public bool isSaved;
    void Start()
    {
        PlayerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        isSaved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isSavable == true){
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (Physics.Raycast(PlayerTrans.position + PlayerTrans.up * 0.75f, PlayerTrans.forward, out hit, MaxDistance))
                {
                    scanObject = hit.transform.gameObject;  
                    if(scanObject == gameObject){
                        gameObject.SetActive(false);
                        Restored.SetActive(true);
                        isSaved = true;
                        gameManager.SavedNPC ++;
                        savedNPC.SetActive(true);
                        NPC.SetActive(false);
                        gameManager.isSavable = false;
                        PressSpace.SetActive(false);
                        Instantiate(DustExplosion, transform.position, transform.rotation);
                    }
                }
            }
            if(isSaved == true){
                PressE.SetActive(false);
            }
        }
    }

}
