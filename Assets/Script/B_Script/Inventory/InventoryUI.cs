using UnityEngine;
using UnityEngine.EventSystems;
public class InventoryUI : MonoBehaviour
{
    #region  Singleton

    public static InventoryUI instance;

    void Awake(){
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public Transform itemsParent;
    public GameObject inventoryUI;
    public GameObject firstJaeryoBtn;

    Inventory inventory;
    public InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        
        //slots = SaveData.instance.SetslotsSave();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            EventSystem.current.SetSelectedGameObject(firstJaeryoBtn);
        }

        
        // SaveData.instance.GetslotsSave(slots);
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }else{
                slots[i].ClearSlot();
            }
        }
    }
}
