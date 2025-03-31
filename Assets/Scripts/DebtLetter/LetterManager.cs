using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManager : MonoBehaviour
{
    public static LetterManager Instance { get; private set; }
    public Events LetterEvent;
    private void Awake()
    {
        if (Instance != null)
        {
            //Debug.LogError("There is more than one instance!");
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }


    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }


}
