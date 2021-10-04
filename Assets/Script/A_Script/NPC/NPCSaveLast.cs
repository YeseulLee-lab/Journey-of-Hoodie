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
            if(Input.GetKeyDown(KeyCode.E)){
                Destroy(PressE);
            }
        }
    }
}
