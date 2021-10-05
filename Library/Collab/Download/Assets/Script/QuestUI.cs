using UnityEngine.EventSystems;
using UnityEngine;

public class QuestUI : MonoBehaviour, IPointerClickHandler 
{
    public GameObject text;
    public GameObject button;
    public void OnPointerClick(PointerEventData eventData) 
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        { 
            Debug.Log("Mouse Click Button : Left");
            text.SetActive(true);
            button.SetActive(true);
            gameObject.SetActive(false);            
        } 
        else if(eventData.button == PointerEventData.InputButton.Middle) 
        { 
            Debug.Log("Mouse Click Button : Middle"); 
        }
        else if(eventData.button == PointerEventData.InputButton.Right) 
        { 
            Debug.Log("Mouse Click Button : Right");
        } 
        Debug.Log("Mouse Position : " + eventData.position); 
        Debug.Log("Mouse Click Count : " + eventData.clickCount); 
    } 
}