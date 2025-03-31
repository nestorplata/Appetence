using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangingButton : MonoBehaviour
{

    Button Button;
    Image Image;
    Sprite ShopSprite;
    [SerializeField]
    Sprite HomeSprite;
    TextMeshProUGUI TextMeshPro;
    int  color = 1;

    private void Start()
    {
        TextMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        Image = GetComponent<Image>();
        Button = GetComponent<Button>();
        Button.onClick.AddListener(ChangeToShop);
        ShopSprite = Image.sprite;

    }
    public void ChangeToShop()
    {
        if(HomeSprite)
        {
            Image.sprite = ShopSprite;


        }
        //color *= -1;
        //TextMeshPro.Bo = ;
        TextMeshPro.text = "Home";
        Button.onClick.RemoveListener(ChangeToShop);
        Button.onClick.AddListener(ChangeToFamily);

    }

    public void ChangeToFamily()
    {
        if (HomeSprite)
        {
            Image.sprite = HomeSprite;
        }
        TextMeshPro.text = "Shop";

        Button.onClick.RemoveListener(ChangeToFamily);
        Button.onClick.AddListener(ChangeToShop);
    }
   
    
}
