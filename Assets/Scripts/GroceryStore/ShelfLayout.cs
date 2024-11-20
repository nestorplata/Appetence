using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShelfLayout : MonoBehaviour
{

    public Button shelfButton;
    public GameObject layout;
    public GameObject placed;
    public bool isShelfOpen = false;

    private bool listenerAdded = false;

    // Start is called before the first frame update
    void Start()
    {
        layout.SetActive(false);
        placed.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!listenerAdded)
        {
            shelfButton.onClick.AddListener(ViewShelf);
            listenerAdded = true;
        }

        if (!isShelfOpen)
        {
            layout.gameObject.SetActive(false);
            placed.gameObject.SetActive(true);
        }

        else
        {
            layout.gameObject.SetActive(true);
            placed.gameObject.SetActive(false);
        }
    }

    public void ViewShelf()
    {
        if (isShelfOpen == false)
        {
            isShelfOpen = true;
        }

        else if (isShelfOpen == true)
        {
            isShelfOpen = false;
        }

    }

}
