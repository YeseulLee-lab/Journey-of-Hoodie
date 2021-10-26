using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCreate : MonoBehaviour
{
    #region  Singleton

    public static WeaponCreate instance;

    void Awake(){
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public List<Sprite> Jaeryo = new List<Sprite>();
    public List<Image> jaeryoImage = new List<Image>();

    public Image Result;

    //리프레시할때 인벤토리에 넣기 위해 따로 아이템 저장공간 만듦
    public List<Item> newItem = new List<Item>();

    public Text amount1Text;
    public Text amount2Text;

    public List<Recipe> recipes = new List<Recipe>();

    

    public void getImageOfJaeryo(Item item)
    {
        //인벤에서 아이템을 선택하면 뉴아이템에 저장
        newItem.Add(item);

        //오류방지
        // if(Jaeryo.Count >= 2)
        // {
        //     Debug.Log("두개모두선택됨");
        //     return;
        // }
        
        
        //크리에이터에 스프라이트 넣기 위해 스프라이트 저장공간에 add
        
        Jaeryo.Add(item.icon);
        Jaeryo = Jaeryo.Distinct().ToList();

        //각 공간에 스프라이트 넣음
        for(int i = 0; i < Jaeryo.Count; i++)
        {
            if(Jaeryo[i] != null)
            {
                jaeryoImage[i].enabled = true;
                jaeryoImage[i].sprite = Jaeryo[i];
            }
        }

        stackJaeryo();

    }

    //잘못 클릭했을 경우를 생각해서 초기화
    public void Refresh()
    {
        Jaeryo.Clear();

        for(int i = 0; i < jaeryoImage.Count; i++)
        {
            jaeryoImage[i].enabled = false;
            jaeryoImage[i].sprite = null;
        }

        //뉴아이템에 저장한 아이템 인벤에 다시 저장하고 인벤토리 유아이 업데이트
        for(int i = 0; i < newItem.Count; i++)
        {
            Inventory.instance.items.Add(newItem[i]);
            InventoryUI.instance.UpdateUI();
            
        }

        newItem.Clear();
        amount1Text.text = "";
        amount2Text.text = "";
        Result.enabled = false;
        Result.sprite = null;
    }

    public void stackJaeryo()
    {
        int id = newItem[0].id;
        int amount1 = 0;
        int amount2 = 0;

        for(int i = 0; i < newItem.Count; i++)
        {
            if(id == newItem[i].id)
            {
                amount1++;
                amount1Text.text = amount1.ToString();
            }else{
                amount2++;
                amount2Text.text = amount2.ToString();
            }
        }
    }

    public void create()
    {
        Debug.Log("만들기 누름");
        
        foreach(Recipe r in recipes)
        {
            Debug.Log("foreach 들어옴");
            
            if(Jaeryo.Count != 0)
            {
                if(Jaeryo[0] == r.Materials[0].Item.icon && Jaeryo[1] == r.Materials[1].Item.icon)
                {
                    Debug.Log("아이템비교" + amount1Text.text +" "+ r.Materials[0].Amount.ToString());

                    if(amount1Text.text == r.Materials[0].Amount.ToString() && amount2Text.text == r.Materials[1].Amount.ToString())
                    {
                        Debug.Log("개수비교");
                        Result.enabled = true;
                        Result.sprite = r.Results[0].Item.icon;
                        WeaponInven.instance.Add(r.Results[0].Item);
                        Jaeryo.Clear();

                        for(int i = 0; i < jaeryoImage.Count; i++)
                        {
                            jaeryoImage[i].enabled = false;
                            jaeryoImage[i].sprite = null;
                        }
                        newItem.Clear();
                        amount1Text.text = "";
                        amount2Text.text = "";
                    }
                }
            }
            
        }
        
    }
}
