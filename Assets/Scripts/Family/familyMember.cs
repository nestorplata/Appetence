using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName = "FamilyMembers", menuName = "ScriptableObjects/FamilyMember", order = 1)]
public class familyMember : ScriptableObject
{
    public FamilyRole Role;
    public Hunger Hunger = Hunger.Fine;
    public Health sickness = Health.Healthy;
    public AudioClip happy;
    public AudioClip Sad;
    public AudioClip sick;

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


}

public enum GeneralState {
    [Description("Satisfied")] Satisfied,
    [Description("Hungry")] Hungry,
    [Description("Sick")] Sick,
    [Description("Dead")] Dead

}
public enum Health { 
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
    [Description("Boy")] Boy,
    [Description("Wife")] Wife,
    [Description("You")] You,
    [Description("Girl")] Girl,
    [Description("Baby")] Baby}


