using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        if(gameObject == isActiveAndEnabled)
        {
            Debug.Log("Pressed left click.");
            gameObject.SetActive(false);
        }

    }
}
