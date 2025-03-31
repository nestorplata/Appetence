using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ShopItemUI : MonoBehaviour
{
    public Color TextColor;
    public TMP_Text itemName;
    public TMP_Text itemDescription;
    public TMP_Text itemCost;
    public Toggle toggleItem;
    public Image itemIcon;
    public Button buyButton;
    private ShopItem currentItem;
    private List<ShopItem> boughtItems = new List<ShopItem>();

    private AnimationsManager familyUIManager;

    private void Start()
    {
       familyUIManager = FindObjectOfType<AnimationsManager>();
    }
    public void Setup(ShopItem item)
    {
        currentItem = item;
        itemName.text = item.itemName;  // Assign item name
        itemDescription.text = item.itemDescription;  // Assign item description
        itemCost.text = item.cost.ToString() +"$";  // Assign item cost
        itemName.color = TextColor;
        itemDescription.color = TextColor;
        itemCost.color = TextColor;

        // Load the availability state
        toggleItem.isOn = true;
        currentItem.available = true;

        itemIcon.sprite = item.itemIcon;  // Assign item icon
        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(BuyItem);

    }

    public void SetupSoldOut(ShopItem item)
    {
        currentItem = item;
        itemName.text = "SOLD OUT";      // Display SOLD OUT
        itemDescription.text = "";       // Clear description
        itemCost.text = "";              // Clear cost
        itemIcon.sprite = item.itemIcon;
        buyButton.interactable = false;  // Disable the buy button
    }

    void BuyItem()
    {
        if (currentItem.available == true)
        {
            SetAvailability(false);
            CurrencySystem.Instance.AddCurrency(-currentItem.cost);
            boughtItems.Add(currentItem);

            // Notify FamilyUIManager to change clothing
            if (familyUIManager != null)
            {
                currentItem.Functionality(this);
            }


        }
        else
        {
            Debug.Log("Not Available");
        }
    }

    public void SetAvailability(bool available)
    {
        currentItem.available = available;
        toggleItem.isOn = available;
        // Save the availability state
        //PlayerPrefs.SetInt(currentItem.itemName + "_available", available ? 1 : 0);
        //PlayerPrefs.Save();
        //Debug.Log($"Saved availability for {currentItem.itemName}: {available}");
    }

}
