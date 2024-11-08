using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LetterScript : MonoBehaviour
{

    private Image Image;
    LetterMenu LetterMenu;

    void Start()
    {
        Image = GetComponent<Image>();
        LetterMenu = FindObjectOfType<LetterMenu>(true);
    }
    public void OnClick()
    {
        LetterMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }


}
