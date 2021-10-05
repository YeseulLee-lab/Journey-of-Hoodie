using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
 
public class Timeline : MonoBehaviour {
 
    public PlayableDirector playableDirector;
    public GameObject talkpanel;

    public void Start() {
    }
 
    public void Update()
    {
        if (playableDirector.gameObject.activeSelf == true){
            playableDirector.Play();
        }

        if (talkpanel.activeSelf == false){
            playableDirector.Stop();
        }
    }
}