using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionFollowCube : MonoBehaviour
{
    public Button Question;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 questionPos = UnityEngine.Camera.main.WorldToScreenPoint(this.transform.position);
        Question.transform.position = questionPos;
    }
}
