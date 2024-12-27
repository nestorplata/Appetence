using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
//using static UnityEditor.Progress;

//Make singleton
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Shop", order = 2)]
public class ShopScriptable : ScriptableObject
{


    [field: SerializeField]
    public GameObject ShopPanelContainer {  get; private set;  }

    [field: SerializeField]
    public GameObject ItemIcon { get; private set; }
    [field: SerializeField]
    public List<ScriptablePanel> ShopPanels { get; private set; }

    ////TESTING VARS
    //private int aliveFamily = 0;
    //private int sickFamily = 0;

    // Start is called before the first frame update
    

    public ScriptablePanel GetPanel(System.Type type)
    {
        foreach(var Panel in ShopPanels)
        {
            if (Panel.GetType() == type) return Panel;
        }
        return null;
    }

}
