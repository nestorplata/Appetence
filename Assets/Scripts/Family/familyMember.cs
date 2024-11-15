using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FamilyMembers", menuName = "ScriptableObjects/FamilyMember", order = 1)]
public class familyMember : ScriptableObject
{
    public string CharactherName;
    public AudioClip happy;
    public AudioClip Sad;
    public AudioClip sick;


}
