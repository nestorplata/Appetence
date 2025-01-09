using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Panel/Clothing", order = 2)]

public class ClothingPanel : ScriptablePanel
{
    public List<ClothingItem> ClothItems;
    private List<ObjectOwner> ShelvesOwners;
    // Start is called before the first frame update
    public override void Instantiate()
    {


       // SetItems(Items);
        // ShopManager.Instance.TechAnimations;
        //foreach (var item in shopItems)
        //{
        //    SetItems
        //    AddItem(item);
        //}
    }
    public override void Assign(List<GameObject> Shelves)
    {
        AssignShelves(Shelves);
        foreach (var Item in ClothItems)
        {
            GameObject Shelve = ObjectOwner.GetRespective(Item.Owner, ShelvesOwners).gameObject;
            GameObject newItem = Instantiate(ShopItemPrefab, Shelve.transform);
            ShopItemUI Icon = newItem.GetComponent<ShopItemUI>();
            Item.Instantiate(Icon);

        }
    }
    public override List<ShopItem> GetItems()
    {
        return ClothItems.ToList<ShopItem>();
    }
    public void AssignShelves(List<GameObject> Shelves)
    {
        ShelvesOwners = new List<ObjectOwner>();
        foreach(GameObject shelve in Shelves)
        {
            ShelvesOwners.Add(shelve.GetComponent<ObjectOwner>());
        }

    }
}

