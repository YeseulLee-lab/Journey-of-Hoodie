using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NpcPet : MonoBehaviour {
  public Transform target; // 따라갈 타겟의 트랜스 폼
  public float dampSpeed = 1;  // 따라가는 속도 짧으면 타겟과 같이 움직인다.
  public GameObject building;

  void Start() {

  }
  void Update () {
    if (building.activeSelf == true){
      //_animation.Play("Walk");
      //Vector3 newPos = target.position + new Vector3(xDistance, relativeHeigth, -zDistance); // 타겟 포지선에 해당 위치를 더해.. 즉 타겟 주변에 위치할 위치를 담는다.. 일정의 거리를 구하는 방법
      Follow();
    }
  }

  void Follow(){
    //var distance = target.position - this.transform.position;
    if (Vector3.Distance(target.position, this.transform.position) > 4){
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * dampSpeed);
        GetComponent<Animation>().Play("Walk");
    }
    else{
      GetComponent<Animation>().Play("Idle");
    }
    transform.LookAt(target);
  }
}