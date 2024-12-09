using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class familyMember : MonoBehaviour
{
    public FamilyRole Role;
    public Hunger Hunger = Hunger.Fine;
    public Sickness sickness = Sickness.Healthy;
    public AudioClip happy;
    public AudioClip Sad;
    public AudioClip sick;
    public ToogleProperties FoodToogle;
    public ToogleProperties MedToogle;
    public int foodCost = 60;
    public int MedCost = 200;
    [Range(0,2)] public int ClothingLevel;
    public List<AnimationState> AnimationStates;
    public ShopItem ShopItem;

    public static string GetStateString(Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        DescriptionAttribute[] attributes =
            (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attributes != null && attributes.Length > 0)
            return attributes[0].Description;
        else
            return value.ToString();
    }

    public GeneralState GetGeneralState()
    {
        return GetGeneralState(this);
    }

    public GeneralState GetGeneralState(familyMember member)
    {
        if (IsDead(member))
        {
            return GeneralState.Dead;
        }
        if ((int)member.sickness > (int)member.Hunger & (int)member.sickness >= 1)
        {
            return GeneralState.Sick;
        }
        if ((int)member.Hunger > 0)
        {
            return GeneralState.Hungry;
        }
        return GeneralState.Satisfied;
    }

    public bool IsDead()
    {
        return IsDead(this);
    }

    public bool IsDead(familyMember member)
    {
        if (member.Hunger >= Hunger.Dead || member.sickness >= Sickness.Dead)
        {
            return true;
        }
        return false;
    }

    public AnimationState GetAnimationsState(GeneralState state)
    {
        foreach (var animationState in AnimationStates)
        {
            if (animationState.State == state) return animationState;
        }
        Debug.Log("Animation not found, returning first");
        return AnimationStates[0];
    }

    public AnimatedFamily GetAnimatedFamily(GeneralState state, int clothinglevel)
    {
        return GetAnimationsState(state).GetAnimatedFamily(clothinglevel);
    }

    public AnimatedFamily GetAnimatedFamily()
    {
        AnimationState state = GetAnimationsState(GetGeneralState());
        //if (state == null) return null;
        /*else */return state.GetAnimatedFamily(ClothingLevel);

    }

    public void ChangeClothing( int Level)
    {
        GetAnimatedFamily().gameObject.SetActive(false);
        if (GetGeneralState()!= GeneralState.Dead)
        {
            ClothingLevel = Level;
            GetAnimatedFamily().gameObject.SetActive(true);
        }
    }

    public void ChangeToCurrentClothing()
    { 
        ChangeClothing(ClothingLevel);
    }

    public void UpdateToogleValues()
    {
        FoodToogle.CostText.text = foodCost.ToString();
        MedToogle.CostText.text = MedCost.ToString();

    }
}

public enum GeneralState {
    [Description("Satisfied")] Satisfied,
    [Description("Hungry")] Hungry,
    [Description("Sick")] Sick,
    [Description("Dead")] Dead

}
public enum Sickness { 
    [Description("Healthy")] Healthy,
    [Description("Sick")] Sick,
    [Description("Bedridden")] Bedridden, 
    [Description("Dead")] Dead 
};

public enum Hunger { 
    [Description("Fine")] Fine,
    [Description("Hungry")] Hungry,
    [Description("Starving")] Starving,
    [Description("Dead")] Dead }

public enum FamilyRole {
    [Description("You")] You,
    [Description("wife")] Wife,
    [Description("boy")] Boy,
    [Description("girl")] Girl,
    [Description("baby")] Baby
}


