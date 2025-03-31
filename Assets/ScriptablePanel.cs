using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ScriptablePanel : ScriptableObject
{
    public Sprite BackGround;
    public GameObject ShopItemPrefab;
    public virtual void Instantiate()
    {
        
        throw new NotImplementedException();
    }
    public virtual void Assign( List<GameObject> Shelves)
    {

    }
    public virtual List<ShopItem> GetItems()
    {
        return new List<ShopItem>();
    }



}
