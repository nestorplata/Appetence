using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToogleProperties : MonoBehaviour
{

    public Toggle Toggle;
    public TextMeshProUGUI CostText;

    public bool IsOn()
    {
        return Toggle.isOn;
    }
}

