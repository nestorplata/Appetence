using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ToogleOwner : ObjectOwner
{

    public Toggle Toggle;
    public AffectsState AffectsState;

    void Start()
    {
        //Debug.Log(Owner);
        //switch (AffectsState)
        //{
        //    case AffectsState.Food:
        //        familyScript.Instance.GetFamilyMember(Owner).FoodToogle = this;
        //        break;
        //    case AffectsState.Medicine:
        //        familyScript.Instance.GetFamilyMember(Owner).MedToogle = this;
        //        break;
        //    default:
        //        break;

        //}
    }

    public void SetToogle()
    {
        Toggle = GetComponent<Toggle>();
    }

    public bool IsOn()
    {
        return Toggle.isOn;
    }
}


public enum AffectsState {Food, Medicine, GeneralState }
