using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
//using static UnityEditor.Progress;

public class Shop : MonoBehaviour
{


    
    [SerializeField]
    private GameObject shopIcon;

    private List<PanelItems> ShopPanels;


    private ShopUI shop;


    ////TESTING VARS
    //private int aliveFamily = 0;
    //private int sickFamily = 0;

    // Start is called before the first frame update
    public void Start()
    {

        ShopPanels.Add(transform.GetComponentInChildren<PanelItems>());

        foreach (var panel in ShopPanels)
        {
            InstantiateShopPanel(panel);
        }
    }

    public void InstantiateShopPanel(PanelItems ShopPanel)
    {
        List<Transform> Shelves = new List<Transform>();


        foreach (Transform Childs in ShopPanel.transform)
        {
            Shelves.Add(Childs);
        }
        int x = 0;
        int y = 0;
        foreach (ClothingItem ShopItem in ShopPanel.shopItems)
        {
            //Setup
            familyMember member = familyScript.Instance.GetFamilyMember(ShopItem.Owner);
            if (!member.ShopItem)
            {
                member.ShopItem = ShopItem;
            }
            if (!member.IsDead())
            {
                if (x == 2)
                {
                    x = 0;
                    y++;
                }
                GameObject newItem = Instantiate(shopIcon, Shelves[y]);
                x++;
                //newItem.transform.localPosition = new Vector3(500, 100 * i, 0);
                //    i++;
                ShopUI icon = newItem.GetComponent<ShopUI>();

                if (member.ClothingLevel >= member.ShopItem.GetFinalUpgradeLevel())
                {
                    icon.SetupSoldOut(member.ShopItem);
                }
                else
                {
                    icon.Setup(member.ShopItem);
                }

            }
        }
    }
}
