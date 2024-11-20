using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;

public class familyMember : MonoBehaviour
{
    public FamilyRole Role;
    public Hunger Hunger = Hunger.Fine;
    public Sickness sickness = Sickness.Healthy;
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


