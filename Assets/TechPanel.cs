using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Panel/Technology", order = 2)]
public class TechPanel : ScriptablePanel
{
    public List<TechItem> TechItems;
    
    public override void Instantiate()
    {
        foreach(var Animation in AnimationsManager.Instance.TechAnimations)
        {
            Animation.Item = GetItem(Animation.TechType);
            GetItem(Animation.TechType).animator = Animation;
            /*TechItem item =*/
            //item.animator = Animation;
        }
    }

    public TechItem GetItem(TechType TechType)
    {
        foreach(var item in TechItems)
        {
            if (item.TechType ==TechType)
            {
                return item;
            }
        }
        return null;
    }
    public override List<ShopItem> GetItems()
    {
        return TechItems.ToList<ShopItem>();
    }


}

