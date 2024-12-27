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

       // ShopManager.Instance.TechAnimations;
    }

    public override List<ShopItem> GetItems()
    {
        return TechItems.ToList<ShopItem>();
    }


}

