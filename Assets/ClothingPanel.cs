using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Panel/Clothing", order = 2)]

public class ClothingPanel : ScriptablePanel
{
    public List<ClothingItem> ClothItems;
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
    public override List<ShopItem> GetItems()
    {
        return ClothItems.ToList<ShopItem>();
    }
}

