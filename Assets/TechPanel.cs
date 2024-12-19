using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class TechPanel : ShopPanel
{
    [SerializeField]
    public Dictionary<TechAnimator, TechItem> Tech;
    
    public Dictionary<int, float> TechIndex;
    
    public List<Technology> technologies;
    

}

[System.Serializable]
public struct Technology
{
    public TechAnimator animator;
    public TechItem item;
}