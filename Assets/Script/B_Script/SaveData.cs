using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    #region  Singleton

    public static SaveData instance;

    void Awake(){
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!");
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }

    #endregion

    public static InventorySlot[] slotsSave;
    public static List<Item> itemsSave = new List<Item>();

    public void GetslotsSave(InventorySlot[] slots)
    {
        slotsSave = slots;
    }

    public InventorySlot[] SetslotsSave()
    {
        return slotsSave;
    }

    public void GetitemsSave(List<Item> items)
    {
        itemsSave = items;
    }

    public List<Item> SetitemsSave(){
        return itemsSave;
    }
}
