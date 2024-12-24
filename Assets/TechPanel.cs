using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Panel/Technology", order = 2)]
public class TechPanel : ShopPanel
{
    public List<TechItem> TechItems;
    public override void Instantiate()
    {

       // ShopManager.Instance.TechAnimations;
    }


}

