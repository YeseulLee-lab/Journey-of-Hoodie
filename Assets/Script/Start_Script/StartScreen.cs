using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartScreen : MonoBehaviour
{
    public GameObject Image;
    public GameObject LogoImage;
    public GameObject LogoText;
    public GameObject ButtonDown;

    public GameObject loginBtn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void DestroyObject(){
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown){
            Image.GetComponent<Animator>().Play("ImageOut");
            LogoImage.GetComponent<Animator>().Play("TitleOut");
            LogoText.GetComponent<Animator>().Play("TitleTextOut");
            ButtonDown.SetActive(false);
            Invoke("DestroyObject", 1.5f);
        }
        EventSystem.current.SetSelectedGameObject(loginBtn);
    }
}
