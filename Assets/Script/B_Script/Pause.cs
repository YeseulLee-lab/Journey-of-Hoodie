using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetButtonDown("Cancel"))
        {
            Pause.SetActive(!Pause.activeSelf);
        }*/
    }

    public void Exit()
    {
        Debug.Log("꺼짐");
        Application.Quit();
    }
}
