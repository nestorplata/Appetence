using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;
//using UnityEditor.Search;

public class GameOverScript : MonoBehaviour
{

    [SerializeField]
    private TMP_Text daysLasted;
    [SerializeField]
    TMP_Text[] familyList;

    [SerializeField]
    private Image[] tombstones;

    [SerializeField]
    private Image[] people;
    

    // Start is called before the first frame update
    void Start()
    {

        daysLasted.text = "You Lasted " + familyScript.Instance.day.ToString() + " Days";

        //SetNames and States
        var i = 0;

        familyMember[] Family = familyScript.Instance.GetFamily();
        //Naming tombstones
        foreach (TMP_Text member in familyList)
        {
            string MemberName = familyMember.GetStateString(Family[i].Role);
            string HungerState = familyMember.GetStateString(Family[i].Hunger);
            string healthState = familyMember.GetStateString(Family[i].sickness);


            //print gameover information
            member.text = MemberName + " - " + HungerState + " - " +healthState;

            Image MemberTombstone = GetOwner(tombstones, Family[i]);
            Image MemberAlive = GetOwner(people, Family[i]);
            switch (Family[i].GetGeneralState())
            {
                case GeneralState.Dead:
                    MemberTombstone.gameObject.SetActive(true);
                    MemberAlive.gameObject.SetActive(false);
                    break;
                default:
                    MemberTombstone.gameObject.SetActive(false);
                    MemberAlive.gameObject.SetActive(true);
                    break;
            }
            i++;
            Debug.Log(MemberName + " - " + HungerState);
        }            





    }


    public void RestartButton()
    {
        familyScript.Instance.Reset();
        SceneManager.LoadScene("Family");
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    public Image GetOwner(Image[] Image, familyMember Member)
    {
        for (int i = 0; i < Image.Length; i++) {
            {
                if(Image[i].GetComponent<ToogleOwner>().Owner == Member.Role)
                {
                    return Image[i];
                }

            }
        }
        Debug.Log(Member + " not recognized");
        return null;

    }


}
