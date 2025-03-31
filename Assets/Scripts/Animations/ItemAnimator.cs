using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimator : MonoBehaviour
{
    Animator animator;


    public void Start()
    {
        animator = GetComponent<Animator>();
        //foreach (var parameter in animator.parameters)
        //{
        //    Debug.Log(parameter.name);
        //}
        //animator.GetParameter;
    }

    public void ChangeUpgradeLevel( int i)
    {

        animator.SetInteger("UpgradeLevel", i);
    }

}

