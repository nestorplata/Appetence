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

    [SerializeField] private  int StartingDay = 0;
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

    public bool DayUpdate(List<FamilyRole> foodList, List<FamilyRole> medList)
    {
        day++;
        int MembersDead = 0;
        foreach (familyMember member in Family)
        {
            if(!IsFamilyMemberDead(member))
            {
                if (foodList.Contains(member.Role))
                {
                    member.Hunger--;
                }
                else
                {
                    member.Hunger++;
                }
                if (medList.Contains(member.Role))
                {
                    member.sickness--;
                }
                else
                {
                    member.sickness++;
                }
            }
            if( IsFamilyMemberDead(member))
            {
                MembersDead++;

                if(member.Role == FamilyRole.You || MembersDead > FamilyAllowedToPerish)
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
        day = 0;

        CurrencySystem.Instance.ResetCurrency();
    }

    //getters, setters and helpers
    public int getDay()
    {
        return day;
    }



    public GeneralState GetGeneralState(FamilyRole Role)
    {
        return GetGeneralState(GetFamilyMember(Role));
    }

    public GeneralState GetGeneralState(familyMember member)
    {
        if (IsFamilyMemberDead(member))
        {
            return GeneralState.Dead;
        }
        if ((int)member.sickness >1)
        {
            return GeneralState.Sick;
        }
        if ((int)member.Hunger > 0)
        {
            return GeneralState.Hungry;
        }
        return GeneralState.Satisfied;
    }

    public familyMember[] GetFamily()
    {
        return Family;
    }

    public bool IsFamilyMemberDead(familyMember member)
    {
        if (member.Hunger >= Hunger.Dead || member.sickness >= Sickness.Dead)
        {
            return true;
        }
        return false;
    }

    public bool IsFamilyMemberDead(FamilyRole Role)
    {
        return IsFamilyMemberDead(GetFamilyMember(Role));

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
            if (GetGeneralState(member)>= LatestGeneralState)
            {
                Closestmember = member;
            }
        }
        return Closestmember;
    }


}






