using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events
{
    public string eventName;
    public string eventDescription;

    public int moneyChange;
    public int stressChange;

    public int FoodMultiplier;
    public int MedMultiplier;
    public bool affectsEconomy;

    public AudioSource sfx;
    public AudioSource sound;


    //Events affecting the player
    public Events(string name, string description, int moneyChange = 0, int stressChange = 0, AudioSource sfx = null) 
    {
        eventName = name;
        eventDescription = description;
        this.moneyChange = moneyChange;
        this.stressChange = stressChange;
        this.sfx = sfx;
    }

    //Events affecting the economy
    public Events(string name, string description, int FoodMultiplier = 1, int MedMultiplier = 1, bool affectsEconomy = true, AudioSource sound = null)
    {
        eventName = name;
        eventDescription = description;
        this.FoodMultiplier = FoodMultiplier;
        this.MedMultiplier = MedMultiplier;
        this.affectsEconomy = affectsEconomy;
        this.sound = sound;
    }

//Events with no affects
public Events(string name, string description)
    {
        eventName = name;
        eventDescription = description;
    }
}
