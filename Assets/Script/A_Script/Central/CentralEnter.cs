using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CentralEnter : MonoBehaviour
{

    public Animator transition;
    public float transitonTime = 1f;
    public GameObject DataObject;

    // Start is called before the first frame update
    void Start()
    {
        DataObject = GameObject.Find("DataObject");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            
            LoadNextLevel();
        }
    }

    public void LoadNextLevel(){
        StartCoroutine(LoadLevel("Loading"));
    }

    IEnumerator LoadLevel(string levelName){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitonTime);

        SceneManager.LoadScene(levelName);
    }
}
