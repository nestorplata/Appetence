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
    
    public List<TechItem> techitems;


}

[System.Serializable]
public class Technology 
{
    public TechAnimator animator;
    public TechItem item;
}