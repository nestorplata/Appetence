using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class ObjectOwner :  MonoBehaviour 
{
    [SerializeField] public FamilyRole Owner;

    public static bool operator == ( ObjectOwner object1, ObjectOwner object2)
    {
        if (object1 is null)
        {
            return object2 is null;
        }  

        return object1.Owner == object2.Owner;
    }

    public static bool operator !=(ObjectOwner object1, ObjectOwner object2)
    {
        return !object1 == object2;
    }
    public static ObjectOwner GetRespective (FamilyRole Role, List<ObjectOwner> owners)
    {
        foreach (var owner in owners)
        {
            if (owner.Owner == Role)
            {
                return owner;
            }
        }
        return null;
    }

    public ObjectOwner GetRespective (List<ObjectOwner> owners)
    {
        foreach(var owner in owners)
            {
            if(owner == this)
            {
                return owner;
            }
        }
        return null;
    }
}
