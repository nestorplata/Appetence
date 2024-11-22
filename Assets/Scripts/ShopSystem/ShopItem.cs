using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ShopItem", order = 1)]
public class ShopItem : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public int cost;
    public bool available;
    public Sprite itemIcon;
    public ShopItem nextUpgrade;  // Next upgrade
    public bool isFinalUpgrade;   // Flag for final upgrade
    public int clothingIndex;
    public string familyMember;
    public FamilyRole Owner;

    void Start()

    {
        //// Accessing properties of a shop item
        //ShopItem firstItem = shopItems[0];
        //firstItem.itemName.Visibility = Visibility.Visible;
        //firstItem.itemName.Text = $"Item Name: {firstItem.itemName}";
        //firstItem.itemDescription.Visibility = Visibility.Visible;
        //firstItem.itemDescription.Text = $"Item Description: {firstItem.itemDescription}"  ;
        //firstItem.cost.Visibility = Visibility.Visible;
        //firstItem.itemDescription.Text = $"Item Cost: {firstItem.cost} " ;
        //// ... and so on

        //firstItem.nextUpgrade.Visibility = Visibility.Hidden;
        //// Checking for upgrades
        //if (firstItem.nextUpgrade != null)
        //{
        //     firstItem.nextUpgrade.Visibility = Visibility.Visible;
        //    firstItem.nextUpgrade.itemName.Text = $"Next Upgrade: {firstItem.nextUpgrade.itemName}";
        //}

        //firstItem.isFinalUpgrade.Visibility = Visibility.Hidden;
        //// Checking if it's a final upgrade
        //if (firstItem.isFinalUpgrade)
        //{
        //    firstItem.isFinalUpgrade.Visibility = Visibility.Visible;
        //    firstItem.isFinalUpgrade.Text ="This is the final upgrade.";
        //}
    }
}

