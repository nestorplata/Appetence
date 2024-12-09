using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ClothingItem", order = 1)]
public class ClothingItem : ScriptableItem
{

    public FamilyRole Owner;

    public int GetFinalUpgradeLevel()
    {
        if (nextUpgrade)
        {
            return nextUpgrade.GetFinalUpgradeLevel();
        }
        return Upgradelevel;
    }

    override public void Functionality(ShopUI UI)
    {

        familyMember member = familyScript.Instance.GetFamilyMember(Owner);

        member.ChangeClothing(Upgradelevel);
        
        // Check for next upgrade
        if (nextUpgrade != null)
        {
            member.ShopItem = nextUpgrade;
            member.foodCost /= 2;
            UI.Setup(member.ShopItem);  // Load the next upgrade
        }
        else if (isFinalUpgrade)
        {

            member.MedCost /= 2;
            UI.SetupSoldOut(this);


        }

        member.UpdateToogleValues();
    }
}

