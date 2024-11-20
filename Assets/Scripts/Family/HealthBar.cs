using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private static Image healthBar;
    private familyScript familyScript;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = this.GetComponent<Image>();
        familyScript = GameObject.Find("FamilyManager").GetComponent<familyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.color = Color.green;
    }

    public void HealthBarRotation(int state)
    {
        if (familyScript.GetFamilyMember(FamilyRole.You).Hunger==Hunger.Fine)
        {
            healthBar.fillAmount = 1f;
            healthBar.color = Color.green;
        }
        else if (familyScript.GetFamilyMember(FamilyRole.You).Hunger == Hunger.Hungry)

        {
            healthBar.fillAmount = .75f;
            healthBar.color = Color.yellow;
        }
        else if (familyScript.GetFamilyMember(FamilyRole.You).Hunger == Hunger.Starving)
        {
            healthBar.fillAmount = .50f;
            healthBar.color = new Color(1.0f, 0.4f, 0f);
        }
        else if (familyScript.GetFamilyMember(FamilyRole.You).sickness == Sickness.Sick)
        {
            healthBar.fillAmount = .25f;
            healthBar.color = Color.red;
        }
    }
}
