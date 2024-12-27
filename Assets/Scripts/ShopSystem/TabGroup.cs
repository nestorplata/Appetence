using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
public class TabGroup : MonoBehaviour
{
    public List<TabButton> buttons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public TabButton tabSelected;
    public List<ShopPanel> panels;
    private GameObject welcomeText;
    [SerializeField] private GameObject label;

    public void Start()
    {
        welcomeText = GameObject.Find("WelcomeText");
        //label = GameObject.Find("Labels");
        //label.SetActive(false);
    }
    public void AddToList(TabButton button)
    {
        if (buttons == null)
        {
            buttons = new List<TabButton>();
        }

        buttons.Add(button);
    }

    public void TabSelected(TabButton button)
    {   
        tabSelected = button;
        ResetTabs();
        button.icon.sprite = tabActive;

        welcomeText.SetActive(false);
        label.SetActive(true);

        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < panels.Count; i++)
        {
            if (i == index)
            {
                panels[i].gameObject.SetActive(true);               
            }
            else
            {
                panels[i].gameObject.SetActive(false);
            }
        }
    }

    public void TabEntered(TabButton button)
    {
        ResetTabs();
        if (tabSelected == null || button != tabSelected)
        {
            button.icon.sprite = tabHover;
        }
    }

    public void TabExit(TabButton button)
    {
        ResetTabs();
    }

    public void ResetTabs()
    {
        foreach (TabButton button in buttons)
        {
            if (tabSelected == null || button != tabSelected)
            {
                button.icon.sprite = tabIdle;
            }
        }

    }
}