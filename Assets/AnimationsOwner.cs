using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimationsOwner : ObjectOwner
{
    [SerializeField] public List<AnimationState> States;

    public void Initialize()
    {
        States = GetComponentsInChildren<AnimationState>().ToList<AnimationState>();
        foreach(var state in States)
        {
            state.Initialize();
        }
    }
}




