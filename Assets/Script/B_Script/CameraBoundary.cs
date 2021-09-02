using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundary : MonoBehaviour
{
    public Transform target;
    //카메라와의 거리   
    public float dist = 7f;
    //카메라의 높이 
    public float height = 5f;
    public Vector3 boundsMax;
    public Vector3 boundsMin;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position - (1 * Vector3.forward * dist) + (Vector3.up * height);
        transform.LookAt(target);
        transform.position = new Vector3 (Mathf.Clamp(transform.position.x, boundsMin.x, boundsMax.x), 
                                            Mathf.Clamp(transform.position.y, boundsMin.y, boundsMax.y),
                                            Mathf.Clamp(transform.position.z, boundsMin.z, boundsMax.z));
    }
}
