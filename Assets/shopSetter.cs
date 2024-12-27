using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class shopSetter : MonoBehaviour
{
    [SerializeField]
    ShopScriptable Scriptable;
    [field: SerializeField]
    public List<ShopPanel> ShopPanels { private set; get; }
    // Start is called before the first frame update

    public void Instantiate()
    {
        
        foreach (var PanelScript in  Scriptable.ShopPanels)
        {
            ShopPanel Panel = Panel = new ShopPanel(PanelScript);

            GameObject PanelObject = Instantiate(Scriptable.ShopPanelContainer, transform);
            PanelObject.AddComponent<ShopPanel>();
            Panel.InstantiateItems(Scriptable.ItemIcon);
            ShopPanels.Add(Panel);
        }
    }

}



