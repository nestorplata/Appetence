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
        foreach (ScriptablePanel ScriptablePanel in  Scriptable.ShopPanels)
        {

            GameObject PanelObject = Instantiate(Scriptable.ShopPanelContainer, transform);
            PanelObject.SetActive(true);
            ShopPanel Panel = PanelObject.GetComponent<ShopPanel>();
            Panel.InstantiateItems(ScriptablePanel, Scriptable.ItemIcon);
            ShopPanels.Add(Panel);


        }
    }

}



