using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diaryawake : MonoBehaviour
{
    public GameObject Diary;
    // Start is called before the first frame update
    void Start()
    {
      //  GameObject.Find("diary").GetComponent<Diary>().state = true;
        gameObject.transform.Find("diary").GetComponent<Diary>().num = 1;
        gameObject.transform.Find("diary").GetComponent<Diary>().state = true;
    }

    // Update is called once per frame
    void Update()
    {
        Diary.GetComponent<Diary>().DiaryStory();
    }
}