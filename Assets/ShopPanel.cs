using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class ShopPanel : ScriptableObject
{
    private List<ShopItem> Items = new List<ShopItem>();
    public virtual void Instantiate()
    {
        
        throw new NotImplementedException();
    }
    //Call this at the end
    public void SetItems(List<ShopItem> items)
        { this.Items = items; }
}
