using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    // Start is called before the first frame update

    public static Skip Instance;
    void Awake(){
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Central")
        {
            GameObject.Find("TimeLine").SetActive(false);
            gameObject.SetActive(false);
        }        
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Central");
    }
}
