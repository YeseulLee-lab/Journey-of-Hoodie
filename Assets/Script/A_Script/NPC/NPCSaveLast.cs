using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSaveLast : MonoBehaviour
{
    public GameObject PressE;
    public float curRotSpeed = 3.0f;
    private Transform PlayerTrans;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(PlayerTrans.position, transform.position) <= 5.0f){
            if(PressE != null)
                PressE.SetActive(true);
            Quaternion targetRotation = Quaternion.LookRotation (PlayerTrans.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * curRotSpeed);	
            if(Input.GetKeyDown(KeyCode.C)){
                if (GameObject.Find("GameManager").GetComponent<GameManager>().SavedNPC == 1){
                    GameObject.Find("GameManager").GetComponent<GameManager>().SavedNPC = 2;
                }
                else if(GameManager.MyGameManager.SavedNPC == 4){
                    GameObject.Find("GameManager").GetComponent<GameManager>().SavedNPC = 5;
                }
                Destroy(PressE);
            }
        }
    }
}
