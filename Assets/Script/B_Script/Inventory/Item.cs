using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public int id;
    public Sprite icon = null;
    public int amount;
    public bool isDefaultItem = false;
    public bool isStackable;
    public GameObject ItemPrefab;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }
}
