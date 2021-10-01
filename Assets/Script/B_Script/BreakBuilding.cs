using UnityEngine;
using UnityEngine.UI;

public class BreakBuilding : Interactable
{
    public Building building;
    public GameObject BuildingWreck;
    public int count;

    public override void Interact()
    {
        base.Interact();
        Break();
        if(Input.GetButtonDown("Break")){
            Debug.Log("부시기");
            //count--;
            if(count == 0){
                gameObject.SetActive(false);
                BuildingWreck.SetActive(true);
            }
        }
    }

    void Break(){
        Debug.Log("Breaking " + building.name);
        
    }
}
