using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSave : MonoBehaviour
{
    public GameManager gameManager;
    private GameObject Player;
    private Transform PlayerTrans;
    public GameObject PressE;
    public GameObject PressSpace;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerTrans = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(PlayerTrans.position, transform.position) <= 10.0f){
            //Instantiate(PressE);
            PressE.SetActive(true);
            if(gameManager.isSavable == true){
                //PressE.SetActive(false);
                //Instantiate(PressSpace);
                PressSpace.SetActive(true);
            }
        }else{
            PressE.SetActive(false);
            //Destroy(PressE);
            PressSpace.SetActive(false);
            //Destroy(PressSpace);
        }        
    }
}
