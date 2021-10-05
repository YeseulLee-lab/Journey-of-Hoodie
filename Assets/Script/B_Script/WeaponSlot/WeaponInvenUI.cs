using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInvenUI : MonoBehaviour
{
    #region  Singleton

    public static WeaponInvenUI instance;

    void Awake(){
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public Transform WeaponParent;
    public GameObject weaponInvenUI;

    WeaponInven weaponInven;
    public WeaponSlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        
        weaponInven = WeaponInven.instance;
        weaponInven.onItemChangedCallback += UpdateUI;

        slots = WeaponParent.GetComponentsInChildren<WeaponSlot>();

        
        //slots = SaveData.instance.SetslotsSave();

    }

    // Update is called once per frame

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < weaponInven.weapons.Count)
            {
                slots[i].AddItem(weaponInven.weapons[i]);
                slots[i].amountText.text = weaponInven.weapons[i].amount.ToString();
            }else{
                slots[i].ClearSlot();
            }
        }
    }
}
