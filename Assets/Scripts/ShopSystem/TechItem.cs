using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item/Technology", order = 2)]

public class TechItem : ShopItem
{
    public TechItem nextUpgrade;  // Next upgrade
    [Range(0,100)]public int SicknessChance = 50;
    public TechType type;
    public TechAnimator animator;
    override public void Functionality(ShopItemUI UI)
    {
        if (nextUpgrade != null)
        {
            animator.addUpgradeLevel();
            UI.Setup(nextUpgrade);  // Load the next upgrade
        }
        else if (isFinalUpgrade)
        {

            UI.SetupSoldOut(this);
        }

        
    }

    override public void Instantiate(ShopItemUI icon)
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

public enum TechType
{
    Heater,

}
