using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour
{
    private Button _button;

    void Awake()
    {
        _button = GetComponent<Button>();
    }

    void Update(){
        if(Input.GetButtonDown("Drop")){
            Debug.Log("지우기");
            gameObject.GetComponentInParent<InventorySlot>().OnRemoveButton();
            _button.onClick.Invoke();
        }
    }
}
