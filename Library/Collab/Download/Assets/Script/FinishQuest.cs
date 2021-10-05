using UnityEngine.EventSystems;
using UnityEngine;

public class FinishQuest : MonoBehaviour, IPointerClickHandler 
{
    public GameObject Questionimage;
    public void OnPointerClick(PointerEventData eventData) 
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        { 
            Debug.Log("Mouse Click Button : Left");
            Questionimage.SetActive(false);            
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