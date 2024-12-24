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
    ShopScriptable ShopPages;
    TechPanel TechPanel;
    List<TechAnimator> TechAnimations;
    public static ShopManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            //Debug.LogError("There is more than one instance!");
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);

        Menu = GetComponent<FamilyMenuScript>();
        Shop = Menu.GetShopUI();

        TechAnimContainer = GetComponentInChildren<TechAnimator>().transform.parent.gameObject;
        TechAnimations = TechAnimContainer.GetComponentsInChildren<TechAnimator>().ToList();
        TabGroup = Shop.GetComponentInChildren<TabGroup>();
        ShopPages = Shop.GetComponentInChildren<ShopScriptable>();
        ShopPages.Instantiate();

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
