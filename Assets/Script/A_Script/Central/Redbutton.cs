using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Redbutton : MonoBehaviour
{
    public GameObject Alert;
    public CameraControl CameraControl;
    public Transform NextPos;
    private Animation Playanim;
    public PlayableDirector timeline;
    public GameObject dl;
    public GameObject RedButtonCam;
    public GameObject MainCam;
    public GameObject IcecreamCam;
    public GameObject ChocoCam;
    public GameObject Button1;
    public GameObject Button2;

    // Start is called before the first frame update
    void Start()
    {
        Playanim = gameObject.GetComponent<Animation>();

        timeline.stopped += OnPlayableDirectorStopped;
    }

    void Update(){
        if(RedButtonCam.activeSelf == true){
                gameObject.GetComponent<Renderer>().material.color = Color.red * Mathf.Abs(Mathf.Sin(10.0f * Time.time));
        }
    }
    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (timeline == aDirector){
            dl.SetActive(true);
            MainCam.SetActive(false);
            RedButtonCam.SetActive(true);

            
            Debug.Log("PlayableDirector named " + aDirector.name + " is now stopped.");

        }
    }

    void OnDisable()
    {
        timeline.stopped -= OnPlayableDirectorStopped;
    }

    // Update is called once per frame
    public void OnMouseOver()
    {
        Playanim.Play("RedButton");
        
    }

    public void OnMouseDown(){
        if(RedButtonCam.activeSelf == true){
            CameraControl.SetMount(NextPos);
            Alert.SetActive(true);
            IcecreamCam.SetActive(true);
            ChocoCam.SetActive(true);
            Button1.SetActive(true);
            Button2.SetActive(true);
            //SceneManager.LoadScene ("B");
        }
    }
}
