using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TechAnimator : MonoBehaviour
{
    Animator m_Animator;
    public TechType type;
    string UpgradeKey = "UpgradeLevel";
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeUpgradeLevel(int i)
    {
        if(i>=0 != i<=3)
        {
            m_Animator.SetInteger(UpgradeKey, i);
        }
        Debug.Log("range not taken");
    }
    public void addUpgradeLevel()
    {
        ChangeUpgradeLevel(m_Animator.GetInteger(UpgradeKey) + 1);
    }
}
