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

    public List<Transform> Shelves;

    ////TESTING VARS
    //private int aliveFamily = 0;
    //private int sickFamily = 0;

    // Start is called before the first frame update
    public void Start()
    {
        int currentDay = familyScript.Instance.getDay();
        foreach(Transform Childs in vertContainer.transform)
        {
            Shelves.Add(Childs);
        }
        int x = 0;
        int y = 0;
        foreach (ShopItem ShopItem in shopItems)
        {
            //Setup
            familyMember member = familyScript.Instance.GetFamilyMember(ShopItem.Owner);
            if(!member.ShopItem)
            {
                member.ShopItem = ShopItem;
            }
            if (!member.IsDead())
            {
                if(x==2)
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

                //if (currentDay == 1)
                //{
                //    //Reset everything
                //    icon.Setup(ShopItem);
                //    icon.SetAvailability(true);
                //    //PlayerPrefs.DeleteAll();
                //    //PlayerPrefs.Save();
                //}
                //else
                //{


                //    //switch()
                //    // icon.SetAvailability(savedAvailability);

                //}
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
