using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FamilyUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject satisfiedState;
    [SerializeField]
    private GameObject hungryState;
    [SerializeField]
    private GameObject starvingState;

    private Dictionary<string, Dictionary<string, GameObject[]>> clothingOptions;

    // Start is called before the first frame update
    void Start()
    {
        clothingOptions = new Dictionary<string, Dictionary<string, GameObject[]>>();

        clothingOptions.Add("satisfied", GetClothingOptionsForEmotion(satisfiedState));
        clothingOptions.Add("hungry", GetClothingOptionsForEmotion(hungryState));
        clothingOptions.Add("starving", GetClothingOptionsForEmotion(starvingState));

        LoadClothingPreferences();
    }

    private void LoadClothingPreferences()
    {
        if (familyScript.Instance.getDay() == 0)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
        else
        {
            foreach (var state in clothingOptions)
            {
                foreach (var member in state.Value)
                {
                    string familyMember = member.Key;
                    GameObject[] clothingOptionsForMember = member.Value;

                    // Get saved clothing index for each family member
                    int savedIndex = PlayerPrefs.GetInt(familyMember + "_clothingIndex", 0);

                    // Ensure the index is within bounds
                    if (savedIndex >= 0 && savedIndex < clothingOptionsForMember.Length)
                    {
                        // Disable all clothing options for the family member in the current emotional state
                        foreach (GameObject clothing in clothingOptionsForMember)
                        {
                            clothing.SetActive(false);
                        }

                        // Enable the selected clothing option
                        clothingOptionsForMember[savedIndex].SetActive(true);
                    }
                }
            }
        }
    }

    private Dictionary<string, GameObject[]> GetClothingOptionsForEmotion(GameObject emotionState)
    {
        var memberClothingOptions = new Dictionary<string, GameObject[]>();

        foreach (Transform familyMember in emotionState.transform)
        {
            if (familyMember.CompareTag("FamilyMember"))
            {
                var clothingList = new List<GameObject>();
                foreach (Transform clothingOption in familyMember)
                {
                    if (clothingOption.CompareTag("Clothing"))
                    {
                        clothingList.Add(clothingOption.gameObject);
                    }
                }
                memberClothingOptions.Add(familyMember.name, clothingList.ToArray());
            }
        }

        return memberClothingOptions;
    }

    public void ChangeEmotionalState(string state)
    {
        satisfiedState.SetActive(false);
        hungryState.SetActive(false);
        starvingState.SetActive(false);

        switch (state.ToLower())
        {
            case "satisfied":
                satisfiedState.SetActive(true);
                break;
            case "hungry":
                hungryState.SetActive(true);
                break;
            case "starving":
                starvingState.SetActive(true);
                break;
            default:
                Debug.LogWarning("Invalid emotional state.");
                break;
        }
    }

    public void ChangeClothing(string familyMember, int clothingIndex)
    {
        string currentState = GetCurrentEmotionalState();
        if (currentState == null || !clothingOptions.ContainsKey(currentState))
        {
            Debug.Log("Invalid or no emotional state set.");
            return;
        }

        var currentClothingOptions = clothingOptions[currentState];
        if (!currentClothingOptions.ContainsKey(familyMember))
        {
            Debug.Log("Invalid family member.");
            return;
        }

        var clothingOptionsForMember = currentClothingOptions[familyMember];

        // Ensure the index is within bounds
        if (clothingIndex < 0 || clothingIndex >= clothingOptionsForMember.Length)
        {
            Debug.Log("Invalid clothing index.");
            return;
        }

        // Disable all clothing options for the family member in the current emotional state
        foreach (GameObject clothing in clothingOptionsForMember)
        {
            clothing.SetActive(false);   
        }

        // Enable the selected clothing option
        clothingOptionsForMember[clothingIndex].SetActive(true);
    }

    private string GetCurrentEmotionalState()
    {
        if (satisfiedState.activeSelf) return "satisfied";
        if (hungryState.activeSelf) return "hungry";
        if (starvingState.activeSelf) return "starving";
        return null;
    }
}
