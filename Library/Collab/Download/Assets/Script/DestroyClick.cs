using UnityEngine;
using UnityEngine.EventSystems;

public class DestroyClick : MonoBehaviour, IPointerClickHandler 
{
    public GameManager manager;
    public void OnPointerClick(PointerEventData eventData) 
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        { 
            Debug.Log("Mouse Click Button : Left");
          //  manager.Question.SetActive(false);
            manager.StartAction();
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