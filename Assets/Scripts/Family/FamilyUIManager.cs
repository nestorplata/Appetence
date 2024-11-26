using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.VersionControl.Asset;

public class FamilyUIManager : MonoBehaviour
{
    //[SerializeField]
    //private GameObject satisfiedState;
    //[SerializeField]
    //private GameObject hungryState;
    //[SerializeField]
    //private GameObject sickState;

    //private Dictionary<string, Dictionary<string, GameObject[]>> clothingOptions;
    public List<AnimationsOwner> Animations;




    // Start is called before the first frame update
    private void Start()
    {
        InitializeAnimations();
        LoadClothingLevel();
        //UpdateAllFamilyClothing();
    }


    private void InitializeAnimations()
    {
        foreach (var Animation in Animations)
        {
            Animation.Initialize();
            familyMember member = familyScript.Instance.GetFamilyMember(Animation.Owner);
            member.AnimationStates = Animation.States;
        }
    }

    private void LoadClothingLevel()
    {

        foreach (var animations in Animations)
        {
            foreach (var state in animations.States)
            {
                foreach (var clothing in state.Clothings)
                {
                    clothing.gameObject.SetActive(false);
                }
            }
        }

        foreach (var member in familyScript.Instance.GetFamily())
        {
            member.GetAnimatedFamily().gameObject.SetActive(true);
        }
    }

    public void ChangeClothing(FamilyRole familyRole, int ClothingLevel)
    {
        familyMember member = familyScript.Instance.GetFamilyMember(familyRole);

        member.GetAnimatedFamily().gameObject.SetActive(false);
        Debug.Log(member.GetAnimatedFamily().gameObject.name);
        member.ClothingLevel = ClothingLevel;
        member.GetAnimatedFamily().gameObject.SetActive(true);
        Debug.Log(member.GetAnimatedFamily().gameObject.name);
    }
}



//private void InitializeClothingOptions()
//{
//    clothingOptions = new Dictionary<string, Dictionary<string, GameObject[]>>();
//    string SatisfiedState = familyMember.GetStateString(GeneralState.Satisfied);
//    string HungryState = familyMember.GetStateString(GeneralState.Hungry);
//    string SickState = familyMember.GetStateString(GeneralState.Sick);



//    clothingOptions.Add(SatisfiedState, GetClothingOptionsForEmotion(satisfiedState));
//    clothingOptions.Add(HungryState, GetClothingOptionsForEmotion(hungryState));
//    clothingOptions.Add(SickState, GetClothingOptionsForEmotion(sickState));


//}


//foreach (var state in clothingOptions)
//{
//    foreach (var member in state.Value)
//    {
//        string familyMember = member.Key;
//        GameObject[] clothingOptionsForMember = member.Value;

//        // Load saved clothing index for each family member and state
//        int savedIndex = PlayerPrefs.GetInt(familyMember + "_" + state.Key + "_clothingIndex", 0);

//        // Ensure the index is within bounds
//        if (savedIndex >= 0 && savedIndex < clothingOptionsForMember.Length)
//        {
//            // Disable all clothing options for the family member in the current emotional state
//            foreach (GameObject clothing in clothingOptionsForMember)
//            {
//                clothing.SetActive(false);
//            }

//            // Enable the selected clothing option
//            clothingOptionsForMember[savedIndex].SetActive(true);
//        }
//    }
//}
//}


//private void UpdateAllFamilyClothing()
//{

//    foreach (familyMember member in familyScript.Instance.GetFamily())
//    {
//        UpdateFamilyMemberClothing(member);
//        //LoadClothingLevel();
//    }

//}

//public void UpdateFamilyMemberClothing(familyMember FamilyMember)
//{

//    string currentRoleString = familyMember.GetStateString(FamilyMember.Role);
//    GeneralState currentState = FamilyMember.GetGeneralState();
//    string currentStateString = familyMember.GetStateString(currentState);
//    if (currentState == GeneralState.Dead)
//    {
//        SetAllClothingInactive(currentRoleString);
//        return;
//    }

//    foreach (var state in clothingOptions)
//    {
//        if (state.Key == currentStateString)
//        {
//            //Debug.Log(state.ToString());
//            // Activate clothing for the current state based on saved preferences
//            ActivateClothingForMember(state.Key, currentRoleString);
//        }
//        else
//        {
//            // Deactivate clothing for other states
//            DeactivateClothingForMember(state.Key, currentRoleString);
//        }


//    }
//}

//private void ActivateClothingForMember(string state, string familyMember)
//{
//    if (!clothingOptions.ContainsKey(state) || !clothingOptions[state].ContainsKey(familyMember))
//    {
//        Debug.Log($"Clothing options for state '{state}' or member '{familyMember}' not found.");
//        //Debug.Log(clothingOptions.ToString());
//        //Debug.Log(clothingOptions.Keys.ToString());
//        //Debug.Log(clothingOptions.Values.ToString());

//        //Debug.Log(state);
//        //Debug.Log(familyMember);


//        return;
//    }

//    GameObject[] clothingOptionsForMember = clothingOptions[state][familyMember];

//    // Retrieve saved clothing index
//    int savedIndex = PlayerPrefs.GetInt(familyMember + "_" + state + "_clothingIndex", 0);

//    // Ensure the index is within bounds
//    if (savedIndex < 0 || savedIndex >= clothingOptionsForMember.Length)
//    {
//        savedIndex = 0; // Fallback to first option
//    }

//    // Disable all clothing options first
//    foreach (GameObject clothing in clothingOptionsForMember)
//    {
//        clothing.SetActive(false);
//    }

//    // Activate the saved clothing option
//    clothingOptionsForMember[savedIndex].SetActive(true);
//}

//private void DeactivateClothingForMember(string state, string familyMember)
//{

//    if (!clothingOptions.ContainsKey(state) || !clothingOptions[state].ContainsKey(familyMember))
//    {
//        Debug.LogError($"Clothing options for state '{state}' or member '{familyMember}' not found.");
//         return;
//    }

//    GameObject[] clothingOptionsForMember = clothingOptions[state][familyMember];

//    foreach (GameObject clothing in clothingOptionsForMember)
//    {
//        clothing.SetActive(false);
//    }
//}

//private void SetAllClothingInactive(string familyMember)
//{
//    foreach (var state in clothingOptions)
//    {
//        if (state.Value.ContainsKey(familyMember))
//        {
//            GameObject[] clothingOptionsForMember = state.Value[familyMember];
//            foreach (GameObject clothing in clothingOptionsForMember)
//            {
//                clothing.SetActive(false);
//            }
//        }
//    }
//}

//private Dictionary<string, GameObject[]> GetClothingOptionsForEmotion(GameObject emotionState)
//{
//    var memberClothingOptions = new Dictionary<string, GameObject[]>();

//    foreach (Transform familyMember in emotionState.transform)
//    {
//        if (familyMember.CompareTag("FamilyMember"))
//        {
//            var clothingList = new List<GameObject>();
//            foreach (Transform clothingOption in familyMember)
//            {
//                if (clothingOption.CompareTag("Clothing"))
//                {
//                    clothingList.Add(clothingOption.gameObject);
//                }
//            }
//            memberClothingOptions.Add(familyMember.name, clothingList.ToArray());
//        }
//    }

//    return memberClothingOptions;
//}


//public void ChangeClothing(string familyRoleString, int clothingIndex)
//{


//    GeneralState[] states = { GeneralState.Satisfied, GeneralState.Hungry, GeneralState.Sick }; // Apply the change to all emotional states

//    foreach (var currentState in states)
//    {
//        string CurrentStateString = familyMember.GetStateString(currentState);
//        if (!clothingOptions.ContainsKey(CurrentStateString) || !clothingOptions[CurrentStateString].ContainsKey(familyRoleString))
//        {


//            Debug.LogError(clothingOptions.Keys.ToString());
//            Debug.LogError($"Clothing options for state '{CurrentStateString}' or member '{familyRoleString}' not found.");
//            return;
//        }

//        GameObject[] clothingOptionsForMember = clothingOptions[CurrentStateString][familyRoleString];

//        // Ensure the index is within bounds
//        if (clothingIndex < 0 || clothingIndex >= clothingOptionsForMember.Length)
//        {
//            Debug.LogError("Invalid clothing index.");
//            return;
//        }

//        // Disable all clothing options for the family member in the current state
//        foreach (GameObject clothing in clothingOptionsForMember)
//        {
//            clothing.SetActive(false);
//        }

//        // Enable the selected clothing option
//        clothingOptionsForMember[clothingIndex].SetActive(true);
//        LoadClothingLevel();

//        // Save the selected clothing index for each state
//        PlayerPrefs.SetInt($"{familyRoleString}_{CurrentStateString}_clothingIndex", clothingIndex);
//    }

//    PlayerPrefs.Save();
//}

//}
