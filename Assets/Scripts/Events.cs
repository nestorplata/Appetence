using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events
{
    public string eventName;
    public string eventDescription;

    public int moneyChange;
    public int stressChange;

    public int foodPrice;
    public int medPrice;
    public bool affectsEconomy;


    //Events affecting the player
    public Events(string name, string description, int moneyChange = 0, int stressChange = 0) 
    {
        eventName = name;
        eventDescription = description;
        this.moneyChange = moneyChange;
        this.stressChange = stressChange;
    }

    //Events affecting the economy
    public Events(string name, string description, int foodPrice = 0, int medPrice = 0, bool affectsEconomy = true)
    {
        eventName = name;
        eventDescription = description;
        this.foodPrice = foodPrice;
        this.medPrice = medPrice;
        this.affectsEconomy = affectsEconomy;
    }

//Events with no affects
public Events(string name, string description)
    {
        eventName = name;
        eventDescription = description;
    }
}
