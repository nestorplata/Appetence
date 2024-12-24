using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Panel/Clothing", order = 2)]

public class ClothingPanel : ShopPanel
{
    [SerializeField]
    public List<ClothingItem> shopItems;
    // Start is called before the first frame update
    public override void Instantiate()
    {

        
        // ShopManager.Instance.TechAnimations;
    }
}
