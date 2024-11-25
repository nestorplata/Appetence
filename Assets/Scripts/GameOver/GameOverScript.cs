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
            i++;

            Image MemberTombstone = searchImageTypeName(tombstones, MemberName);
            Image MemberAlive = searchImageTypeName(people, MemberName);
            switch (HungerState)
            {
                case "Dead":
                    MemberTombstone.gameObject.SetActive(true);
                    MemberAlive.gameObject.SetActive(false);
                    break;
                default:
                    MemberTombstone.gameObject.SetActive(false);
                    MemberAlive.gameObject.SetActive(true);
                    break;
            }
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

    public Image searchImageTypeName(Image[] Images, string Member)
    {
        for (int i = 0; i < Images.Length; i++) {
            {
                string ObjectName = Images[i].gameObject.name;
                bool containsName = ObjectName.IndexOf(Member, System.StringComparison.OrdinalIgnoreCase) >= 0;
                if(containsName)
                {
                    return Images[i];
                }
            }
        }
        Debug.Log(Member + " not recognized");
        return null;

    }


}
