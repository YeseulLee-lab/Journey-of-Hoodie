using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    private Animation Playanim;
    public AnimationClip Floating;
    public CameraControl CameraControl;
    public Transform NextSelect;
    public GameObject back;

    public GameObject login;

    // Start is called before the first frame update
    void Start()
    {
        Playanim = gameObject.GetComponent<Animation>();
        //Playanim.enabled = false;
        Playanim["Roundcube|RoundcubeAction"].speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
        //Playanim.enabled = true;
        Playanim["Roundcube|RoundcubeAction"].speed = 1;
    }

    public void OnMouseExit()
    {
        //Playanim.enabled = false;
        //Playanim.CrossFade(Floating.name, 0);
        Playanim["Roundcube|RoundcubeAction"].speed = 0;
    }

    public void OnMouseDown()
    {
        if(login.GetComponent<Login>().success == true){
            CameraControl.SetMount(NextSelect);
            back.SetActive(true);
        }
        else{
            Debug.Log("로그인하지 않음");
        }
        
    }
}
