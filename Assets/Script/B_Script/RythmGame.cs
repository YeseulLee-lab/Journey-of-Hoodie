using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RythmGame : MonoBehaviour
{
    public float circleShrinkSpeed = 8f;
    public RectTransform targetCircle;
    public RectTransform shrinkCircle;
    RaycastHit hit;
    public Text count;
    public GameObject[] Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        hit = Player[0].GetComponent<MapIcePlayer>().hit;
    //    hit = FindObjectOfType<MapIcePlayer>().hit;
        shrinkCircle.sizeDelta -= new Vector2(1, 1) * Time.deltaTime * circleShrinkSpeed;
        if(gameObject.activeSelf == true)
        {
            if(Input.GetButtonDown("Break"))
            {
                Debug.Log(hit.collider.name);
                if(Mathf.CeilToInt(shrinkCircle.sizeDelta.x) <= targetCircle.sizeDelta.x + 3 && Mathf.CeilToInt(shrinkCircle.sizeDelta.x) >= targetCircle.sizeDelta.x - 3)
                {
                    hit.collider.GetComponent<BreakBuilding>().count--;
                    shrinkCircle.sizeDelta = new Vector2(100, 100);
                    Debug.Log("리듬탁");
                    count.text = hit.collider.GetComponent<BreakBuilding>().count.ToString();
                }
                else
                {
                    shrinkCircle.sizeDelta = new Vector2(100, 100);
                    count.text = "다시";
                }
                    
            }
        }
    }
}