using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopSetter : MonoBehaviour
{
    [SerializeField]
    ShopScriptable Base;
    // Start is called before the first frame update

    private void Start()
    {
        Instantiate();
    }
    public void Instantiate()
    {
        Base.ShopWindow = Instantiate(Base.ShopWindow, transform);
        foreach (var panel in  Base.ShopPanels)
        {
            InstantiateShopPanel(panel);
            panel.Instantiate();
        }
    }

    public void InstantiateShopPanel(ShopPanel ShopPanel)
    {
        List<Transform> Shelves = new List<Transform>();

        //foreach (Transform Childs in ShopPanel.transform)
        //{
        //    Shelves.Add(Childs);
        //}
        //Vector2 Shelve = Vector2.zero;


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
}
