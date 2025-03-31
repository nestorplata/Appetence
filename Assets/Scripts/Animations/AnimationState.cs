using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimationState : MonoBehaviour
{
    [SerializeField] public GeneralState State;
    [SerializeField] public List<AnimatedFamily> Clothings;
    public void Initialize()
    {
        Clothings = GetComponentsInChildren<AnimatedFamily>(true).ToList<AnimatedFamily>();
        
    }

    public AnimatedFamily GetAnimatedFamily(int ClothingLevel)
    {
        return Clothings[ClothingLevel];
    }
}
