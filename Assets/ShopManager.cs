using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    FamilyMenuScript Menu;
    GameObject Shop;
    GameObject TechAnimContainer;
    TabGroup TabGroup;
    ShopPages ShopPages;
    TechPanel TechPanel;
    public List<TechAnimator> TechAnimations;

    
    // Start is called before the first frame update
    void Start()
    {
        Menu = GetComponent<FamilyMenuScript>();
        Shop = Menu.GetShopUI();

        TechAnimContainer = GetComponentInChildren<TechAnimator>().transform.parent.gameObject;
        TechAnimations = TechAnimContainer.GetComponentsInChildren<TechAnimator>().ToList();
        TabGroup = GetComponentInChildren<TabGroup>();
        ShopPages = GetComponentInChildren<ShopPages>();
        TechPanel = ShopPages.GetComponentInChildren<TechPanel>();

    }

    public void AssignAnimations()
    {
        
        foreach (var Item in TechPanel.techitems)
        {
            Item.animator = ReturnType(Item.type);
        }
    }

    public TechAnimator ReturnType(TechType type)
    {
        foreach (TechAnimator item in TechAnimations)
        {
            if (type == item.type)
            {
                return item;
            }
        }

        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
