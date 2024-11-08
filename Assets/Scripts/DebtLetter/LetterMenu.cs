using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterMenu : MonoBehaviour
{
    public LetterScript Letter;
    public LetterOptionsScript Options;
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
        Letter.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    //public void ActivateLetter()
    //{
    //    Letter.gameObject.SetActive(true);
    //}
}
