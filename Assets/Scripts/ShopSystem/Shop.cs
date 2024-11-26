using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using static UnityEditor.Progress;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private ShopItem[] shopItems;

    [SerializeField]
    private GameObject shopIcon;

    [SerializeField]
    private GameObject vertContainer;

    private ShopUI shop;

    ////TESTING VARS
    //private int aliveFamily = 0;
    //private int sickFamily = 0;

    // Start is called before the first frame update
    void Start()
    {
        int currentDay = familyScript.Instance.getDay();

        foreach (ShopItem ShopItem in shopItems)
        {
            //Setup
            GameObject newItem = Instantiate(shopIcon, vertContainer.transform);
            ShopUI icon = newItem.GetComponent<ShopUI>();

            if (currentDay == 1)
            {
                //Reset everything
                icon.Setup(ShopItem);
                icon.SetAvailability(true);
                //PlayerPrefs.DeleteAll();
                //PlayerPrefs.Save();
            }
            else
            {
                bool upgradeExists = PlayerPrefs.GetInt(ShopItem.nextUpgrade.itemName + "_available", ShopItem.nextUpgrade.available ? 1 : 0) == 1;
                bool baseExists = PlayerPrefs.GetInt(ShopItem.itemName + "_available", ShopItem.available ? 1 : 0) == 1;

                //switch()
                // icon.SetAvailability(savedAvailability);
                if (!baseExists && !upgradeExists)
                {
                    icon.SetupSoldOut(ShopItem);
                }
                else if (baseExists)
                {
                    icon.Setup(ShopItem);
                }
                else
                {
                    icon.Setup(ShopItem.nextUpgrade);
                }
            }

        }

        /* var i = 0; //TEMP
         aliveFamily = Random.Range(1, 5);
         sickFamily = Random.Range(0, aliveFamily);

         foreach (ShopItem shop in shopItems)
         {
             //Setup
             GameObject newItem = Instantiate(shopIcon);
             ShopUI icon = newItem.GetComponent<ShopUI>();

             //Create new slot
             icon.itemName.text = shop.itemName;


             //LOGIC PER ITEM (TEMP)
             if (i == 0)//Food
             {
                 icon.itemCost.text = (shop.cost* aliveFamily).ToString();
                 newItem.transform.parent = vertContainer.transform;
             }
             else //Med
             {
                 icon.itemCost.text = (shop.cost * sickFamily).ToString();
                 if (sickFamily > 0)
                 {
                     newItem.transform.parent = vertContainer.transform;
                 }
                 else
                 {
                     Destroy(newItem);
                 }
             }
             icon.itemIcon.sprite = shop.itemIcon;
             i++;
         }

         Debug.Log("alive "+aliveFamily);
         Debug.Log("sick "+sickFamily);*/
    }
}
