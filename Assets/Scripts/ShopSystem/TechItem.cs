using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TechItem", order = 2)]

public class TechItem : ShopItem
{
    public TechItem nextUpgrade;  // Next upgrade
    [Range(0,100)]public int SicknessChance = 50;
    TechAnimator animator;
    override public void Functionality(ShopUI UI)
    {
        if (nextUpgrade != null)
        {
            UI.Setup(nextUpgrade);  // Load the next upgrade
        }
        else if (isFinalUpgrade)
        {

            UI.SetupSoldOut(this);
        }

        
    }

    override public void Instantiate(ShopUI icon)
    {
        

        icon.Setup(this);

        if (UpgradeLevel >= GetFinalUpgradeLevel())
        {
            icon.SetupSoldOut(this);
        }

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
