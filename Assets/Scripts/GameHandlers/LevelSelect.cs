using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

    public Button FactoryButton;
    public Button GroceryButton;
    [SerializeField]
    private LevelLoader levelLoader;

    // Start is called before the first frame update
    void Start()
    {

        FactoryButton.onClick.AddListener(() => LoadFactory());
        GroceryButton.onClick.AddListener(() => LoadGrocery());

        if(familyScript.Instance.day ==1)
        {
            int random = Random.Range(0, 2);

            GameObject DeactivateJob;
            switch (random)
            {
                case 1:
                    DeactivateJob = FactoryButton.gameObject;
                    break;
                default:
                    DeactivateJob = GroceryButton.gameObject;

                    break;
            }
            DeactivateJob.SetActive(false);
        }

    }


        // Update is called once per frame
    public void LoadFactory()
    {
        StartCoroutine(levelLoader.LoadLevel("FactoryTutorial"));
    }

    public void LoadGrocery()
    {
        StartCoroutine(levelLoader.LoadLevel("GroceryStoreTutorial"));
    }
}
