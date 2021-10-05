using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NpcPet2 : MonoBehaviour {
  public Transform target; // 따라갈 타겟의 트랜스 폼
  public float dampSpeed = 1;  // 따라가는 속도 짧으면 타겟과 같이 움직인다.
  public GameObject timeline;

  void Start() {

  }
  void Update () {
    if (GameObject.Find("Player").GetComponent<PlayerMove>().a >= 3){
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