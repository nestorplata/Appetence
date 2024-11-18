using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FamilyMembers", menuName = "ScriptableObjects/FamilyMember", order = 1)]
public class familyMember : ScriptableObject
{
    public string CharactherName;
    public Hunger Hunger = Hunger.Fine;
    public Health Health = Health.Healthy;
    public AudioClip happy;
    public AudioClip Sad;
    public AudioClip sick;


}

public class Family
{


}
public enum Health { Healthy, Sick, Bedridden, Dead };

public enum Hunger { Fine, Hungry, Starving, Dead }
