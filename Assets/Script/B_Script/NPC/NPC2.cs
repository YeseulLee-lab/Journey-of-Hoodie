using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC2 : MonoBehaviour
{
    public GameObject Building;
    Animator anim;
    float curRotSpeed = 10f;
    private Transform PlayerTrans;
    public GameObject PressC;
    public GameObject talkPanel;
    public GameObject Particle;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        PlayerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 questionPos = UnityEngine.Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0,5, 0));
        PressC.transform.position = questionPos;

        Quaternion targetRotation = Quaternion.LookRotation ((Building.transform.position - new Vector3(0,5, 0)) - transform.position);
      transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * curRotSpeed);
        if(Building.activeSelf == true){
            anim.SetBool("isFix", true);
            //Particle.SetActive(true);
        }
        else{
            anim.SetBool("isFix", false);
            //Particle.SetActive(false);
        }

        if(GameManager.MyGameManager.SelectPanel.activeSelf == true)
        {
            
        }
        else if(GameObject.FindWithTag("Player").GetComponent<MapIcePlayer>().Allpercent >= 50)
        {
            if(Vector3.Distance(transform.position, PlayerTrans.position) <= 5f)
            {
                if(GameObject.Find("Canvas").transform.Find("Select").gameObject.GetComponent<SelectMod>().destroying == true)
                {
                    //Debug.Log("어쩔겨?");
                    PressC.SetActive(true);
                    PressC.GetComponentInChildren<Text>().text = "C";
                    if(Input.GetButtonDown("Enter"))
                    {
                        GameManager.MyGameManager.Action(gameObject);
                    }
                }
                
            }
            else{
                PressC.SetActive(false);
            }
        }
    }
}