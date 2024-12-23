using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
//using static UnityEditor.Progress;

public class ShopPages : MonoBehaviour
{


    
    [SerializeField]
    private GameObject shopIcon;

    public List<ShopPanel> ShopPanels;

    ////TESTING VARS
    //private int aliveFamily = 0;
    //private int sickFamily = 0;

    // Start is called before the first frame update
    public void Instantiate()
    {
        ShopPanels = transform.GetComponentsInChildren<ShopPanel>(true).ToList();
        foreach (var panel in ShopPanels)
        {
            InstantiateShopPanel(panel);
            panel.Instantiate();
        }
    }

    public void InstantiateShopPanel(ShopPanel ShopPanel)
    {
        List<Transform> Shelves = new List<Transform>();

        foreach (Transform Childs in ShopPanel.transform)
        {
            Shelves.Add(Childs);
        }
        Vector2 Shelve = Vector2.zero;


        //foreach (var Item in ShopPanel.shopItems)
        //{
            
        //    if (Shelve.x == 2)
        //    {
        //        Shelve.x = 0;
        //        Shelve.y++;
        //    }
        //    GameObject newItem = Instantiate(shopIcon, Shelves[(int)Shelve.y]);
        //    Shelve.x++;
        //    ShopItemUI Icon = newItem.GetComponent<ShopItemUI>();

        //    Item.Instantiate(Icon);


        //}
    }

    public ShopPanel GetPanel(System.Type type)
    {
        foreach(var Panel in ShopPanels)
        {
            if (Panel.GetType() == type) return Panel;
        }
        return null;
    }

}
