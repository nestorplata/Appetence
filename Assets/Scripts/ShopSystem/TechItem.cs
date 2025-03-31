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
    public TechType TechType;
    public TechAnimator animator;
    override public void Instantiate(ShopItemUI icon)
    {


        icon.Setup(this);

        //if (UpgradeLevel >= GetFinalUpgradeLevel())
        //{
        //    icon.SetupSoldOut(this);
        //}


    }
    override public void Functionality(ShopItemUI UI)
    {
        animator.addUpgradeLevel();
        if (!isFinalUpgrade())
        {
            UI.Setup(nextUpgrade);  // Load the next upgrade
            nextUpgrade.animator = animator;
        }
        else 
        {

            UI.SetupSoldOut(this);
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
    public bool isFinalUpgrade()
    {
        return !nextUpgrade;
    }
}

public enum TechType
{
    Heater,

}
