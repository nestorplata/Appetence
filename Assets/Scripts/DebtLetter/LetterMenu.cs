using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterMenu : MonoBehaviour
{
    public LetterScript Letter;
    public delegate void OnClick();

    void Start()
    {
        Letter = FindObjectOfType<LetterScript>(true);

    }

    public void OnClosePressed()
    {
        Letter.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public void OnYesPressed()
    {
        if(CurrencySystem.Instance.GetCurrency()>=2000)
        {
            Letter.gameObject.SetActive(false);
            LetterManager.Instance.LetterEvent = null;
            CurrencySystem.Instance.AddCurrency(-2000);
            gameObject.SetActive(false);
        }

    }
    //public void ActivateLetter()
    //{
    //    Letter.gameObject.SetActive(true);
    //}
}
