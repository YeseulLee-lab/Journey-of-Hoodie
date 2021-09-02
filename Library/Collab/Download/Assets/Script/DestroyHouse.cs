using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHouse : MonoBehaviour
{
    RaycastHit hit;
    float MaxDistance = 15f;
    public GameObject scanObject;
    public GameManager manager;

    public GameObject house;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            Destroy(house);
        }

    }

    void OnTriggerEnter(Collider other) {
        //manager.Action(scanObject);              
    }
}
