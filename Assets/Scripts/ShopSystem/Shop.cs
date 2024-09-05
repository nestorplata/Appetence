using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private ShopItem[] shopItems;

    [SerializeField]
    private GameObject shopIcon;

    [SerializeField]
    private GameObject vertContainer;

    private ShopUI shop;

    //TESTING VARS
    private int aliveFamily = 0;
    private int sickFamily = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (ShopItem shop in shopItems)
        {
            //Setup
            GameObject newItem = Instantiate(shopIcon, vertContainer.transform);
            ShopUI icon = newItem.GetComponent<ShopUI>();

            // Set the shop item data
            icon.Setup(shop);

            if (familyScript.Instance.getDay() == 0)
            {
                icon.SetAvailability(true);
                PlayerPrefs.DeleteAll();
                PlayerPrefs.Save();
            }

            bool savedAvailability = PlayerPrefs.GetInt(shop.itemName + "_available", shop.available ? 1 : 0) == 1;
            icon.SetAvailability(savedAvailability);
            if (!savedAvailability)
            {
                icon.itemName.text = "SOLD OUT";
                icon.itemDescription.text = "";
                icon.itemCost.text = "";
                icon.buyButton.interactable = false;
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
