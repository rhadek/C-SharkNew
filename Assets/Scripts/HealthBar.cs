using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthbar;
    [SerializeField] private Image healthbar1;
    public void UpdateHealthBar(float MaxHealth, float Health)
    {
        if ((Health / MaxHealth) == 1)
        {
            healthbar.enabled = false;
            healthbar1.enabled = false;
        }
        else
        {
            healthbar.enabled = true;
            healthbar1.enabled = true;
        }
        healthbar.fillAmount = Health / MaxHealth;
    }
}
