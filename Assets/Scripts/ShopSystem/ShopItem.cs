using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ShopItem", order = 1)]

public class ShopItem : ScriptableObject
{
    
    public string itemName = "Affects the price of food";
    public string itemDescription = "Cheapens food price";
    public int cost;
    public bool available;
    public Sprite itemIcon;
    public bool isFinalUpgrade;   // Flag for final upgrade
    [Range(1, 2)] public int UpgradeLevel;



    public virtual void Functionality(ShopItemUI UI) { }
    public virtual void Instantiate(ShopItemUI icon) {}




}
