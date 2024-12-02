using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class familyScript : MonoBehaviour
{
    [SerializeField] familyMember[] Family;

    public static int StartingDay { get; private set; } = 1;
    [Range(0, 4)] public int FamilyAllowedToPerish =1;


    public static familyScript Instance { get; private set; }
    

    [HideInInspector]public int day = 0;


    void Awake()
    {
        if (Instance != null)
        {
            //Debug.LogError("There is more than one instance!");
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        day = StartingDay;
        DontDestroyOnLoad(transform.gameObject);

    }

    public bool DayUpdate()
    {
        day++;
        int MembersDead = 0;
        foreach (familyMember member in Family)
        {
            if(!member.IsDead())
            {
                if (member.FoodToogle.IsOn())
                {
                    member.Hunger--;
                }
                else
                {
                    member.Hunger++;
                }
                if (member.MedToogle.IsOn())
                {
                    member.sickness--;
                }
                else
                {
                    member.sickness++;
                }
            }


        }
        foreach (familyMember member in Family)
        {

            if (member.IsDead())
            {
                MembersDead++;

                if (member.Role == FamilyRole.You || MembersDead > FamilyAllowedToPerish)
                {
                    return true;
                }

            }
        }

        return false;
    }
    public void Reset()
    {
        for (int i = 0; i < Family.Length; i++)
        {
            Family[i].Hunger = Hunger.Fine;
            Family[i].sickness = Sickness.Healthy;
            //FamilyDeathList[i] = 0;
        }
        day = StartingDay;

        CurrencySystem.Instance.ResetCurrency();
    }

    //getters, setters and helpers
    public int getDay()
    {
        return day;
    }


    public familyMember[] GetFamily()
    {
        return Family;
    }



    public familyMember GetFamilyMember(FamilyRole DesiredMember)
    {
        foreach (var member in Family)
        {
            if(member.Role == DesiredMember) return member;
        }
        Debug.Log("FamilyMember not found, returning first member");
        return Family[0];

    }

    public familyMember GetClosestToDead()
    {
        GeneralState LatestGeneralState = GeneralState.Satisfied;
        familyMember Closestmember = null;
        foreach (var member in Family)
        {
            if (member.GetGeneralState()>= LatestGeneralState && member.GetGeneralState()!>=GeneralState.Dead)
            {
                Closestmember = member;
            }
        }
        return Closestmember;
    }

    public bool IsFirstDay()
    {
        return StartingDay == day;
    }

}






