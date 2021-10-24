using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTRG : MonoBehaviour
{
    public GameObject spawnposition;
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().controller.enabled = false;
            GameObject.FindGameObjectWithTag("Player").transform.position = spawnposition.transform.position;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().controller.enabled = true;
            Instantiate(particle,  GameObject.FindGameObjectWithTag("Player").transform.position + transform.up * 0.3f,  GameObject.FindGameObjectWithTag("Player").transform.rotation);
            print(GameObject.FindGameObjectWithTag("Player").name);
            print("떨어짐");
        }
    }
}
