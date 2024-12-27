using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopPanel : MonoBehaviour
{
    public ScriptablePanel ScriptablePanel;
    public List<GameObject> Shelves;

    public ShopPanel(ScriptablePanel Panel)
    {
        this.ScriptablePanel = Panel;

    }
    public void InstantiateItems(GameObject ItemIcon)
    {
        ScriptablePanel.Instantiate();
        foreach (Transform shelve in transform)
        {
            Shelves.Add(shelve.gameObject);
        }
        Vector2 ShelvePosition = Vector2.zero;

        foreach (var Item in ScriptablePanel.Items)
        {
            if (ShelvePosition.x == 2)
            {
                ShelvePosition.x = 0;
                ShelvePosition.y++;
            }
            GameObject newItem = Instantiate(ItemIcon, Shelves[(int)ShelvePosition.y].transform);
            ShelvePosition.x++;
            ShopItemUI Icon = newItem.GetComponent<ShopItemUI>();

            Item.Instantiate(Icon);


        }
    }
}

