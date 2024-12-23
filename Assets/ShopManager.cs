using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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
    public static ShopManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Menu = GetComponent<FamilyMenuScript>();
        Shop = Menu.GetShopUI();

        TechAnimContainer = GetComponentInChildren<TechAnimator>().transform.parent.gameObject;
        TechAnimations = TechAnimContainer.GetComponentsInChildren<TechAnimator>().ToList();
        TabGroup = Shop.GetComponentInChildren<TabGroup>();
        ShopPages = Shop.GetComponentInChildren<ShopPages>();
        ShopPages.Instantiate();

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
