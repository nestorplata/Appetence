using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    [SerializeField] private int StartingCurrency;
    private int currency; //if changed, also change in Reset() function in familyScript

    public static CurrencySystem Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            //Debug.LogError("There is more than one instance!");
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        currency = StartingCurrency;
    }

    public void AddCurrency(int amount)
    {
        currency += amount;
        
    }

    public int GetCurrency()
    {
        return currency;
    }

    public void SetCurrency(int cur)
    {
        currency = cur;
    }

    public void ResetCurrency()
    {
        currency = StartingCurrency;
    }
}
