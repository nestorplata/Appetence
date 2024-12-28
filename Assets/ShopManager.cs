using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ShopManager : MonoBehaviour
{


    TabGroup TabGroup;
    shopSetter ShopSetter;



    // Start is called before the first frame update
    public void Start()
    {


        TabGroup = GetComponentInChildren<TabGroup>();
        ShopSetter = GetComponentInChildren<shopSetter>();

        ShopSetter.Instantiate();
        TabGroup.panels = ShopSetter.ShopPanels;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
