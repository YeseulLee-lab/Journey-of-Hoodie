using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class PrefabTimline : MonoBehaviour
{
    public PlayableDirector timeline;
    public Animator anim;
    public GameObject Player;
    public GameObject Camera;

    public static void BindAnimator(PlayableDirector director, string trackName, Animator animator)
    {
        TimelineAsset timeline = director.playableAsset as TimelineAsset;
        foreach (var track in timeline.GetOutputTracks())
        {
            if (track.name == trackName)
            {
                director.SetGenericBinding(track, animator);
                break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Camera");
        //Player = GameObject.Find("MultiPlayer(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        if(null != GameObject.Find("MultiPlayer(Clone)")){
            anim = GameObject.Find("MultiPlayer(Clone)").GetComponent<Animator>();
        }
        
        BindAnimator(timeline, "Animation Track", anim);
        BindAnimator(timeline, "Animation Track (1)", anim);
    }
}