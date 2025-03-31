using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ToogleOwner : ObjectOwner
{

    public ToogleProperties FoodToogle;
    public ToogleProperties MedToogle;
    public TextMeshProUGUI MemberLabel;

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




}


public enum AffectsState {Food, Medicine, GeneralState }
