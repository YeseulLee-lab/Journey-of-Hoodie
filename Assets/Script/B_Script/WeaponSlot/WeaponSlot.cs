using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlot : MonoBehaviour
{
    public static InventorySlot instance;
    public Image icon;
    public Button ItemButton;
    public Text amountText;
    Item item;

    public GameObject small;
    public GameObject medium;
    public GameObject fork;
    public GameObject Building1;
    public GameObject Building2;
    public GameObject Building3;
    public GameObject select;
    public void AddItem (Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        amountText.enabled = true;
        ItemButton.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        amountText.enabled = false;
        ItemButton.enabled = false;
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
            if(select.GetComponent<SelectMod>().destroying == true)
            {
                if(item.id == 100)
                {
                    small.SetActive(true);
                    medium.SetActive(false);
                    fork.SetActive(false);
                }
                else if(item.id == 200)
                {
                    small.SetActive(false);
                    medium.SetActive(true);
                    fork.SetActive(false);
                }
                else if(item.id == 300)
                {
                    small.SetActive(false);
                    medium.SetActive(false);
                    fork.SetActive(true);
                }
            }
            else if(select.GetComponent<SelectMod>().destroying == false)
            {
                if(item.id == 1000)
                {
                    Building1.SetActive(true);
                    Building2.SetActive(false);
                    Building3.SetActive(false);
                }
                else if(item.id == 2000)
                {
                    Building1.SetActive(false);
                    Building2.SetActive(true);
                    Building3.SetActive(false);
                }
                else if(item.id == 3000)
                {
                    Building1.SetActive(false);
                    Building2.SetActive(false);
                    Building3.SetActive(true);
                }
            }
            
        }
    }
}