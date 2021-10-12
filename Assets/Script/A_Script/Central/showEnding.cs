using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class showEnding : MonoBehaviour
{
    public PlayableDirector timeline;
    public GameObject Next;

    // Start is called before the first frame update
    void Start()
    {
        timeline.stopped += OnPlayableDirectorStopped;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (timeline == aDirector){
            Next.SetActive(true);

            Debug.Log("PlayableDirector named " + aDirector.name + " is now stopped.");

        }
    }

    void OnDisable()
    {
        timeline.stopped -= OnPlayableDirectorStopped;
    }

    public void toStart()
    {
        SceneManager.LoadScene ("Start");
    }
}
