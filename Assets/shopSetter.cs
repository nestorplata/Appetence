using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class shopSetter : MonoBehaviour
{
    [SerializeField]
    ShopScriptable ScriptableShop;
    [field: SerializeField]
    public List<ShopPanel> ShopPanels { private set; get; }
    // Start is called before the first frame update

    public void Instantiate()
    {
        foreach (ScriptablePanel ScriptablePanel in  ScriptableShop.ShopPanels)
        {

            ShopPanel Panel = Instantiate(ScriptableShop.ShopPanelContainer, transform).GetComponent<ShopPanel>();
            Panel.gameObject.SetActive(true);
            Panel.SetImage(ScriptablePanel.BackGround);
            Panel.InstantiateItems(ScriptablePanel, ScriptableShop.ItemIcon);
            ShopPanels.Add(Panel);


        }
    }

}



