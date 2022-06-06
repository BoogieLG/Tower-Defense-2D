using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarComponent : MonoBehaviour
{
    [SerializeField] HealthComponent healthComponent;
    [SerializeField] Image healthBar;

    private void Start()
    {
        healthComponent.OnChangeHealth += setImage;
    }

    private void OnDestroy()
    {
        healthComponent.OnChangeHealth -= setImage;
    }
    private void setImage(float maxHealth, float currentHealth)
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
