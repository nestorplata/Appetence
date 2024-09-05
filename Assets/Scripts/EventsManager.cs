using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EventsManager : MonoBehaviour
{
    public List<Events> events = new List<Events>();
    public GameObject panel;
    public TextMeshProUGUI descriptionText;
    private Scene currentScene;

    private int previousEventIndex = -1;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        
        // Add events
        //negative
        events.Add(new Events("Car Breakdown", "Your car broke down, and you had to pay 200 coins for repairs", -200, 0));
        events.Add(new Events("Speeding Ticket", "You were pulled over for speeding and got a ticket for 100 coins", -100, 0));
        events.Add(new Events("Injury", "Work injuries, pay 100 coins", -100, 0));

        //positive
        events.Add(new Events("Lucky Find", "You found 40 coins on the floor when coming out of work", 40, 0));
        events.Add(new Events("Lottery", "You won a random lottery at work and were given 100 coins", 100, 0));
        events.Add(new Events("Welfare", "Asked government for welfare and got 75 coins", 75, 0));
        events.Add(new Events("Charity", "Charity help gave 25 coins", 25, 0));
        events.Add(new Events("Promotion", "Your boss notices you, you got 30 extra coins", 30, 0));

        OnSceneLoaded();
    }
    public void TriggerRandomEvent()
    {
        if (events.Count == 0) return;

        int randomIndex;

        do
        {
            randomIndex = Random.Range(0, events.Count);
        }
        while (randomIndex == previousEventIndex);

        previousEventIndex = randomIndex;
        Events selectedEvent = events[randomIndex];

        OpenPanel(selectedEvent.eventDescription);
        AffectPlayer(selectedEvent);
       // Debug.Log("Show panel");
    }

    public void OpenPanel(string description)
    {
        panel.SetActive(true);
        descriptionText.text = description;
    }

    public void AffectPlayer(Events selectedEvent)
    {
        CurrencySystem.Instance.AddCurrency(selectedEvent.moneyChange);
       // Debug.Log("Affecting player");
    }

    private void OnSceneLoaded()
    {
        // Check if the loaded scene is the family scene
        if (currentScene.name == "Family")
        {
           // Debug.Log("Checked scene: Family");
            // Show the random event
            if (familyScript.Instance.getDay() != 0)
            {
                //Debug.Log("Triggered");
                TriggerRandomEvent();
            }
        }
    }

    public void ExitPanel()
    {
        panel.SetActive(false);
    }
}
