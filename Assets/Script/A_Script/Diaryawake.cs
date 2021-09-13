using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diaryawake : MonoBehaviour
{
    public GameObject Diary;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Diary.GetComponent<Diary>().DiaryStory();
    }
}
