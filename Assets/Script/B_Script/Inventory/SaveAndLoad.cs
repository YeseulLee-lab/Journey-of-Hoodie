using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    Inventory inv;
    WeaponInven wpinv;

    public Item[] items;
    public Item[] weapons;
    string icenickname;

    private void Start()
    {
        inv = GetComponent<Inventory>();
        wpinv = GetComponent<WeaponInven>();

        if(null != GameObject.Find("DataObject")){
            icenickname = GameObject.Find("DataObject").GetComponent<TransData>().icenickname;
        }
        else{
            icenickname = "아이스";
        }
    }

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.S)){
            Save();
        }else if(Input.GetKeyDown(KeyCode.L)){
            Load();
        }
        
    }
    public void Save()
    {
        List<ItemLoad> itemsToLoad = new List<ItemLoad>();
        List<ItemLoad> weaponsToLoad = new List<ItemLoad>();

        for(int i = 0; i < Inventory.instance.items.Count; i++)
        {
            Item z = Inventory.instance.items[i];
            if (!z.isDefaultItem)
            {
                ItemLoad h = new ItemLoad(z.id, i);
                itemsToLoad.Add(h);
                Debug.Log(h.id);
            }else if(z == null)
            {
                
            }
        }

        for(int i = 0; i< WeaponInven.instance.weapons.Count; i++)
        {
            Item z = WeaponInven.instance.weapons[i];
            if(!z.isDefaultItem)
            {
                ItemLoad h = new ItemLoad(z.id, i);
                weaponsToLoad.Add(h);
                Debug.Log(h.id);
            }
            else if(z == null)
            {

            }
        }

        string json = customJSON.ToJson(itemsToLoad);
        string jsonWp = customJSON.ToJson(weaponsToLoad);

        File.WriteAllText(Application.persistentDataPath + icenickname, json);
        File.WriteAllText(Application.persistentDataPath + icenickname + "weapon", jsonWp);

        Debug.Log("Saving...");
    }

    public void Load()
    {
        Debug.Log("Loading...");
        
        List<ItemLoad> itemsToLoad = customJSON.FromJson<ItemLoad>(File.ReadAllText(Application.persistentDataPath + icenickname));
        List<ItemLoad> weaponsToLoad = customJSON.FromJson<ItemLoad>(File.ReadAllText(Application.persistentDataPath + icenickname + "weapon"));
        //Debug.Log(Application.persistentDataPath);
        //Debug.Log(InventoryUI.instance.slots.Length);
        //Debug.Log(WeaponInvenUI.instance.slots.Length);

        if(itemsToLoad.Count == 0)
        {
            //Debug.Log("뭐임?");
        }else{
            for(int i = itemsToLoad[0].slotIndex; i < InventoryUI.instance.slots.Length; i++)
            {
                foreach(ItemLoad z in itemsToLoad)
                {
                    //Debug.Log(z.id);
                    if(i == z.slotIndex)
                    {
                        Item b = Instantiate(items[z.id]);
                        if(itemsToLoad.Count == Inventory.instance.items.Count)
                        {
                            Inventory.instance.items.Remove(b);
                            break;
                        }
                        
                        //InventorySlot.instance.ClearSlot();
                        Inventory.instance.items.Add(b);
                        InventoryUI.instance.UpdateUI();

                        //Debug.Log("넣는중,...");

                        //Debug.Log("itemsToLoad.Count: " + itemsToLoad.Count);
                        //Debug.Log("items.Length: " + Inventory.instance.items.Count);
                        //break;
                        
                    }
                }
            }
        }

        if(weaponsToLoad.Count == 0)
        {

        }
        else{
            for(int i = weaponsToLoad[0].slotIndex; i < WeaponInvenUI.instance.slots.Length; i++)
            {
                foreach(ItemLoad z in weaponsToLoad)
                {
                    //Debug.Log(z.id);
                    if(i == z.slotIndex)
                    {
                        Item c = Instantiate(weapons[(z.id/100)-1]);
                        if(weaponsToLoad.Count == WeaponInven.instance.weapons.Count)
                        {
                            WeaponInven.instance.weapons.Remove(c);
                            break;
                        }
                        
                        //InventorySlot.instance.ClearSlot();
                        WeaponInven.instance.weapons.Add(c);
                        WeaponInvenUI.instance.UpdateUI();
                        //Debug.Log("넣는중,...");
                        //Debug.Log("weaponsToLoad.Count: " + weaponsToLoad.Count);
                        //Debug.Log("items.Length: " + WeaponInven.instance.weapons.Count);
                        //break;
                        
                    }
                }
            } 
        }
        
    }
}

[System.Serializable]
public class ItemLoad
{
    public int id, slotIndex;

    public ItemLoad(int ID, int SLOTINDEX)
    {
        id = ID;
        slotIndex = SLOTINDEX;
    }
}
