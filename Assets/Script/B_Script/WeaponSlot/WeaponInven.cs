using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInven : MonoBehaviour
{
    #region  Singleton

    public static WeaponInven instance;

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

    public int space = 5;
    public List<Item> weapons = new List<Item>();

    int amount = 1;

    public bool Add(Item item){

        if(!item.isDefaultItem)
        {
            if(weapons.Count >= space)
            {
                Debug.Log ("공간 없음");
                return false;
            }
            if (item.isStackable)
            {
                bool itemAlreadyInInven = false;
                foreach(Item invenItem in weapons)
                {
                    if(invenItem.id == item.id)
                    {
                        invenItem.amount += amount;
                        itemAlreadyInInven = true;
                    }
                }
                if(!itemAlreadyInInven){
                    weapons.Add(item);
                }
            }else{
                weapons.Add(item);
            }
            
            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }        

        return true;
    }

    public void Remove (Item item)
    {
        weapons.Remove(item);

        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
