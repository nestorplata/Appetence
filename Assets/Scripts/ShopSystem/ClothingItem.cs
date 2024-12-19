using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ClothingItem", order = 1)]
public class ClothingItem : ShopItem
{
    public FamilyRole Owner;
    private familyMember member;
    public ClothingItem nextUpgrade;  // Next upgrade

    override public void Functionality(ShopUI UI)
    {


        member.ChangeClothing(UpgradeLevel);

        // Check for next upgrade
        if (nextUpgrade != null)
        {
            nextUpgrade.setMember(member);
            member.CurrentClothing = nextUpgrade;
            member.foodCost /= 2;
            UI.Setup(member.CurrentClothing);  // Load the next upgrade
        }
        else if (isFinalUpgrade)
        {

            member.MedCost /= 2;
            UI.SetupSoldOut(this);


        }

        member.UpdateToogleValues();
    }

    override public void Instantiate(ShopUI icon)
    {
        setMember(familyScript.Instance.GetFamilyMember(Owner));

        icon.Setup(this);

        if (member.CurrentClothing&&
            member.ClothingLevel >= member.CurrentClothing.GetFinalUpgradeLevel())
        {
            icon.SetupSoldOut(member.CurrentClothing);
        }


    }

    public void setMember(familyMember Member)
    {
        member = Member;
    }
    public int GetFinalUpgradeLevel()
    {
        if (nextUpgrade)
        {
            return nextUpgrade.GetFinalUpgradeLevel();
        }
        return UpgradeLevel;
    }


}

