using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopPanel : MonoBehaviour
{
    public ScriptablePanel ScriptablePanel;
    public List<GameObject> Shelves;
    public Image Image;


    public void InstantiateItems(ScriptablePanel ScriptablePanel, GameObject ItemIcon)
    {
        this.ScriptablePanel = ScriptablePanel;

        foreach (Transform shelve in transform)
        {

            Shelves.Add(shelve.gameObject);
        }

        ScriptablePanel.Instantiate();
        ScriptablePanel.Assign(Shelves);
        /*OldShelve Code
        //Vector2 ShelvePosition = Vector2.zero;

        //foreach (var Item in ScriptablePanel.GetItems())
        //{
        //    if (ShelvePosition.x == 2)
        //    {
        //        ShelvePosition.x = 0;
        //        ShelvePosition.y++;
        //    }
        //    GameObject newItem = Instantiate(ItemIcon, Shelves[(int)ShelvePosition.y].transform);
        //    ShelvePosition.x++;
        //    ShopItemUI Icon = newItem.GetComponent<ShopItemUI>();
        //             Item.Instantiate(Icon);



        //}
        */
    }

    public void SetImage(Sprite sprite)
    {
        Image =GetComponent<Image>();
        Image.sprite = sprite;
        
    }
}

