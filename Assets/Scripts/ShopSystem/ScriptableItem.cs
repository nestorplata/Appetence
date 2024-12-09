using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableItem : ScriptableObject
{

    public string itemName = "Affects the price of food";
    public string itemDescription = "Cheapens food price";
    public int cost;
    public bool available;
    public Sprite itemIcon;
    public ClothingItem nextUpgrade;  // Next upgrade
    public bool isFinalUpgrade;   // Flag for final upgrade
    [Range(1, 2)] public int Upgradelevel;

    public virtual void Functionality(ShopUI UI) { }
}
