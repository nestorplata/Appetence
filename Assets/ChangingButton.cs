using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingButton : MonoBehaviour
{

    Button Button;
    Image Image;
    Sprite ShopSprite;
    [SerializeField]
    Sprite HomeSprite;

    private void Start()
    {
        
        Image = GetComponent<Image>();
        Button = GetComponent<Button>();
        Button.onClick.AddListener(ChangeMainSprite);
        ShopSprite = Image.sprite;

    }
    public void ChangeMainSprite()
    {
        if(Image.sprite==ShopSprite)
        {
            Image.sprite = HomeSprite;
        }
        else
        {
            Image.sprite = ShopSprite;

        }
    }
}
