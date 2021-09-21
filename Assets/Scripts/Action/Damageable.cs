using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Damageable", menuName = "Hung/Character Property/Damageable")]
public class Damageable : ScriptableObject
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    public float Change(float signedAmmount)
    {
        currentHealth += signedAmmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        return currentHealth / maxHealth;
    }

    public void Refresh()
    {
        currentHealth = maxHealth;
    }
}
