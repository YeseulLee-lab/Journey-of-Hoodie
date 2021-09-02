using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{

    //추적할 대상
    public Transform target;
    //카메라와의 거리   
    public float dist = 7f;
    //카메라의 높이 
    public float height = 5f;
    private Transform tr;
    // Use this for initialization

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    //Update is called once per frame
    void Update()
    {
        //카메라 위치 설정
        tr.position = target.position - (1 * Vector3.forward * dist) + (Vector3.up * height);
        tr.LookAt(target);
    }
}