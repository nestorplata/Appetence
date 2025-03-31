using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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



    [SerializeField]
    private GameObject tutorialBackground;

    [SerializeField]
    private TMP_Text tutorialText;

    [SerializeField]
    private TMP_Text currency;

    //[SerializeField]
    //private TMP_Text Food;
    //[SerializeField]
    //private TMP_Text Medicine;
    [SerializeField]
    private TMP_Text totalCost;

    [SerializeField]
    private Button nextDayBtn;

    [SerializeField]
    private LevelLoader levelLoader;

    [SerializeField]
    private ToogleOwner[] TogList;



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
        if(familyScript.Instance.day > familyScript.StartingDay)
        {
            tutorialBackground.SetActive(false);
            tutorialText.enabled = false;
        }
        foreach (familyMember member in familyScript.Instance.GetFamily())
        {
            SetRespectiveToogle(TogList, member);


            bool IsSick = member.sickness == Sickness.Sick || member.sickness == Sickness.Bedridden;
            member.MedToogle.gameObject.SetActive(IsSick);

            member.FoodToogle.gameObject.SetActive(!member.IsDead());
        }
        
        
        

        //UpdateGameOverText();

    }



    public void SetRespectiveToogle(ToogleOwner[] Toggles, familyMember member)
    {
        foreach (ToogleOwner Toggle in Toggles)
        {
            if (Toggle.Owner == member.Role)
            {
                member.MedToogle = Toggle.MedToogle;
                member.FoodToogle = Toggle.FoodToogle;
                member.UpdateToogleValues();




            }
        }

    }

    private void OnDestroy()
    {
        nextDayBtn.onClick.RemoveListener(OnNextDayButtonClick);
    }

    public void Update()
    {
        currency.text = CurrencySystem.Instance.GetCurrency().ToString() + "$";

        totalCost.text = GetSelectedTotalCost().ToString() + "$";

        if (CurrencySystem.Instance.GetCurrency() < GetSelectedTotalCost() && GetSelectedTotalCost() != 0)
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


    public List<FamilyRole> UpdateOwnersList(ToogleOwner[] ToogleOwners)
    {
        List<FamilyRole> ButtonOwners =  new List<FamilyRole>();
        foreach (ToogleOwner FoodButoon in ToogleOwners)
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
        return ButtonOwners;
    }

    private void OnNextDayButtonClick()
    {
        NextDayIsClicked = true;
        nextDayBtn.interactable = false;
        bool IsGameOver = familyScript.Instance.DayUpdate();
        CurrencySystem.Instance.AddCurrency(-GetSelectedTotalCost());
      
        if (IsGameOver)
        {
            // familyScript.Instance.FamilyListText = UpdateGameOverText();
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            StartCoroutine(levelLoader.LoadLevel("LevelSelect"));
        }
    }

    public void ShopButton()
    {
        shopUI.SetActive(!shopUI.activeSelf);

    }



    private int GetSelectedTotalCost()
    {
        totalCostVal = 0;
        foreach (familyMember member in familyScript.Instance.GetFamily())
        {
           
            if (member.FoodToogle.IsOn() )
            {
                totalCostVal += member.foodCost;
            }
            if (/*member.MedToogle &&*/ member.MedToogle.IsOn())
            {
                totalCostVal += member.MedCost;
            }
        }

        // totalCostVal = foodList.Count * GetFoodCost()+ medList.Count * GetMedCost();
        if (CurrencySystem.Instance.GetCurrency() < 0 && totalCostVal <= 0)
        {
            return 0;
        }

        return totalCostVal;
    }

    public int GetTotalCost()
    {
        int total = 0;
        //total = foodList.Count * GetFoodCost();
        foreach (familyMember member in familyScript.Instance.GetFamily())
        {
            if(member.GetGeneralState() != GeneralState.Dead)
            {
                total += member.foodCost;

                if(member.sickness == Sickness.Sick || member.sickness == Sickness.Bedridden)
                {
                    total += member.MedCost;
                }
            }

        }


        return total;
    }    

    public GameObject GetShopUI()
    {
        return shopUI;
    }




}
