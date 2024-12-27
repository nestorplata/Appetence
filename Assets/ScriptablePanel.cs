using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class ScriptablePanel : ScriptableObject
{
    [field: SerializeField]
    public List<ShopItem> Items { get; private set; }
    public virtual void Instantiate()
    {
        
        throw new NotImplementedException();
    }
    //Call this at the end
    public void SetItems(List<ShopItem> items)
        { this.Items = items; }
}
