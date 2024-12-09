using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ShopItem", order = 1)]
public class ShopItem : ScriptableObject
{
    public string itemName = "Affects the price of food";
    public string itemDescription = "Cheapens food price";
    public int cost;
    public bool available;
    public Sprite itemIcon;
    public ShopItem nextUpgrade;  // Next upgrade
    public bool isFinalUpgrade;   // Flag for final upgrade
    [Range(1,2)]public int Upgradelevel;
    public FamilyRole Owner;

    public int GetFinalUpgradeLevel()
    {
        if(nextUpgrade)
        {
            return nextUpgrade.GetFinalUpgradeLevel();
        }
        return Upgradelevel;
    }
}

