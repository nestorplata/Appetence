using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LetterScript : Button
{
    private ButtonLetterScript ButtonLetterScript;
    enum LetterStates
    {
        Closed,
        Opened
    }

    LetterStates OnLetterState;

    public void Start()
    {
        base.Start();
        ButtonLetterScript = GetComponent<ButtonLetterScript>();
    }



    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        switch (OnLetterState)
        {
            case LetterStates.Closed:
                ButtonLetterScript.OpenLetter();
                interactable = false;

                break;
            case LetterStates.Opened:
                ButtonLetterScript.CloseLetter();
                interactable = true;
                break;

            default:
                print("On Click debt letter not recognized");
                break;

        }
    }

}
