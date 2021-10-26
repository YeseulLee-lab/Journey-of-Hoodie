using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endingTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other) {
        if(GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercent >= 100){
            if(GameObject.Find("SaveManager").GetComponent<Bpercent>().state == true){
                SceneManager.LoadScene("DestroyEnding");
            }
            else{
                SceneManager.LoadScene("RestoreEnding");
            }
        }
    }
}
