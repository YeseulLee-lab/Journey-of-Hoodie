using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public static InventorySlot instance;
    public Image icon;
    public Button removeButton;
    public Button ItemButton;
    public GameObject weaponCreator;

    GameObject Player;
    Item item;

    // void Start()
    // {
    //     icon = SaveData.instance.SeticonSave();
    // }

    void Update()
    {
        
    }

    public void AddItem (Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
        ItemButton.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
        ItemButton.enabled = false;
    }

    public void OnRemoveButton()
    {
        Debug.Log(item.ItemPrefab.name);
        Player = GameObject.FindGameObjectWithTag("Player");
        Instantiate(item.ItemPrefab, Player.transform.position + transform.up * 3.0f, item.ItemPrefab.gameObject.transform.rotation);
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if(Input.GetButtonDown("Drop"))
        {

        }
        else if (item != null)
        {
            item.Use();
            Debug.Log(item.name);
            if(weaponCreator.activeSelf == true)
            {
                WeaponCreate.instance.getImageOfJaeryo(item);

                icon.sprite = null;
                icon.enabled = false;
                removeButton.interactable = false;
                ItemButton.enabled = false;
                Inventory.instance.Remove(item);
            }
            
        }else{
            Debug.Log("안되는디");
        }
    }
}
