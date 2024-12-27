using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class ScriptablePanel : ScriptableObject
{
    
    public virtual void Instantiate()
    {
        
        throw new NotImplementedException();
    }
    public virtual List<ShopItem> GetItems()
    {
        return new List<ShopItem>();
    }



}
