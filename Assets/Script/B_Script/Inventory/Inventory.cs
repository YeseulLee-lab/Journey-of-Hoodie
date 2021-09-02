using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    #region  Singleton

    public static Inventory instance;

    void Awake(){
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public int space = 20;
    public List<Item> items = new List<Item>();

    // void Start()
    // {
        
    //     items = SaveData.instance.SetitemsSave();
    // }

    // void Update()
    // {
    //     SaveData.instance.GetitemsSave(items);
    // }
    public bool Add(Item item){

        if(!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log ("공간 없음");
                return false;
            }

            items.Add(item);
            
            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }        

        return true;
    }

    public void Remove (Item item)
    {
        items.Remove(item);

        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
