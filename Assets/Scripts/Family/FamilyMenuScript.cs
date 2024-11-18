using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FamilyMenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject playUI;
    [SerializeField]
    private GameObject settingsUI;
    private bool SettingsMenu = false;

    [SerializeField] 
    private GameObject shopUI;
    private bool shopMenu = false;

    [SerializeField]
    private GameObject tutorialBackground;

    [SerializeField]
    private TMP_Text tutorialText;


    [SerializeField]
    List<FamilyRole> foodList;
    [SerializeField]
    List<FamilyRole> medList;

    [SerializeField]
    TMP_Text[] familyList;

    [SerializeField]
    private TMP_Text currency;

    [SerializeField]
    private TMP_Text Food;
    [SerializeField]
    private TMP_Text Medicine;
    [SerializeField]
    private TMP_Text totalCost;

    [SerializeField]
    private Button nextDayBtn;

    [SerializeField]
    private LevelLoader levelLoader;

    [SerializeField]
    private GameObject[] FoodTogList;

    

    [SerializeField]
    private GameObject[] MedTogList;

    [SerializeField]
    private int daysToWin = 10;

    [SerializeField]
    private string gameWonScene = "TODO";

    [SerializeField]
    private AudioSource purchaseSFX;

    [SerializeField]
    private AudioClip foodPurchase;

	[SerializeField]
	private AudioClip medPurchase;


	[SerializeField]
    private TMP_Text dayDisplay;
    [SerializeField]
    private int totalCostVal;
    [SerializeField]
    private int foodCost = 60;

    private int medCost = 200;

    private familyScript FamilyScript;

    private bool NextDayIsClicked = false;



    public void Start()
    {
        nextDayBtn.gameObject.SetActive(true);
        nextDayBtn.onClick.AddListener(OnNextDayButtonClick);
        
        dayDisplay.text = "Day " + familyScript.Instance.day.ToString();
        
        if (familyScript.Instance.day >= daysToWin)
        {
            SceneManager.LoadScene(gameWonScene);
        }

        if(familyScript.Instance.day > 0){
            tutorialBackground.SetActive(false);
            tutorialText.enabled = false;
        }

        //UpdateGameOverText();

    }

    //public TMP_Text[] UpdateGameOverText()
    //{

    //    familyMember[] Family = familyScript.Instance.GetFamily();
    //    for (int i = 0; i < Family.Length; i++)
    //    {
    //        familyList[i].text = Family[i].CharactherName + " - " + HungerValues[(int)Family[i].Hunger] + " - " + SicknessValues[(int)Family[i].sickness];
    //        if (Family[i].sickness == Health.Sick || Family[i].sickness == Health.Bedridden)
    //        {
    //            GetRespectiveToogle(MedTogList, Family[i].Role).SetActive(true);

    //        }
    //        if (familyScript.Instance.IsFamilyMemberDead(Family[i]))
    //        {
    //            GetRespectiveToogle(FoodTogList, Family[i].Role).SetActive(false);
    //            GetRespectiveToogle(MedTogList, Family[i].Role).SetActive(false);
    //        }
    //    }
    //    return familyList;
    //}

    public GameObject GetRespectiveToogle(GameObject[] Toggles, FamilyRole role)
    {
        foreach ( GameObject Toggle in Toggles)
        {
            if (Toggle.GetComponent<ToogleOwner>().Owner == role)
            {
                return Toggle;
            }
        }
        return null;

    }

    private void OnDestroy()
    {
        nextDayBtn.onClick.RemoveListener(OnNextDayButtonClick);
    }

    public void Update()
    {
        currency.text = CurrencySystem.Instance.GetCurrency().ToString();

        totalCost.text = CalcTotal().ToString();

        if (CurrencySystem.Instance.GetCurrency() < CalcTotal() && CalcTotal() != 0)
        {
            //totalCost.text = "TOO MUCH!";
            nextDayBtn.gameObject.SetActive(false);
        }
        else
        {
            nextDayBtn.gameObject.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            MenuChange();
        }
        if (Input.GetMouseButtonDown(0)){
            tutorialBackground.SetActive(false);
            tutorialText.enabled = false;
        }
    }
    public void MenuChange()
    {
        if(SettingsMenu){
            playUI.SetActive(true);
            settingsUI.SetActive(false);
            SettingsMenu = false;
        }
        else{
            playUI.SetActive(false);
            settingsUI.SetActive(true);
            SettingsMenu = true;
        }
        
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    public void MainMenuButton()
    {
        familyScript.Instance.Reset();

        SceneManager.LoadScene("Main Menu");
    }

    public void UpdateButton()
    {

        UpdateButtonList(FoodTogList, foodList);
        UpdateButtonList(MedTogList, medList);


        bool dead = familyScript.Instance.DayUpdate(foodList, medList);
        CurrencySystem.Instance.AddCurrency(-CalcTotal());
        if(dead){
           // familyScript.Instance.FamilyListText = UpdateGameOverText();
            SceneManager.LoadScene("GameOver");
        }
        else{
            StartCoroutine(levelLoader.LoadLevel("LevelSelect"));
        }
    }

    public void UpdateButtonList(GameObject[] Bottons, List<FamilyRole> ButtonOwners)
    {
        foreach (GameObject FoodButoon in Bottons)
        {
            FamilyRole owner = FoodButoon.GetComponent<ToogleOwner>().Owner;
            if (FoodButoon.GetComponent<Toggle>().isOn)
            {
                ButtonOwners.Add(owner);
            }
            else if (ButtonOwners.Contains(owner))
            {
                ButtonOwners.Remove(owner);
            }
        }
    }

    private void OnNextDayButtonClick()
    {
        NextDayIsClicked = true;
        nextDayBtn.interactable = false;
        UpdateButton();
    }

    public void ShopButton()
    {
        if (shopMenu)
        {
            shopUI.SetActive(false);
            shopMenu = false;
        }
        else
        {
            shopUI.SetActive(true);
            shopMenu = true;
        }
    }



    private int CalcTotal()
    {
        totalCostVal = 0;
        totalCostVal = foodList.Count * GetFoodCost()+ medList.Count * GetMedCost();


        if (CurrencySystem.Instance.GetCurrency() < 0 && totalCostVal <= 0)
        {
            return 0;
        }

        return totalCostVal;
    }

    public int GetTotalCost()
    {
        int total = 0;
        total = foodList.Count * GetFoodCost() + medList.Count * GetMedCost();

        return total;
    }    

    public void SetFoodCost(int newFoodCost)
    {
        foodCost = newFoodCost;
        Food.text = "Food - " + newFoodCost.ToString();
    }

    public int GetFoodCost()
    {
        return foodCost;
    }

    public void SetMedCost(int newMedCost)
    {
        medCost = newMedCost;
        Medicine.text = "Medicine - " + newMedCost.ToString();
    }

    public int GetMedCost()
    {
        return medCost;
    }

}
